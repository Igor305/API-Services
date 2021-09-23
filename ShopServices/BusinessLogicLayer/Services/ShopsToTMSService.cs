using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ShopsToTMSService : IShopsToTMSService
    {
        private readonly IShopsRepository _shopsRepository;
        private readonly IShopWorkTimesRepository _shopWorkTimesRepository;
        private readonly ICitiesLocalizationRepository _citiesLocalizationRepository;
        private readonly IStreetsLocalizationRepository _streetsLocalizationRepository;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ShopsToTMSService(IShopsRepository shopsRepository, IShopWorkTimesRepository shopWorkTimesRepository,
            ICitiesLocalizationRepository citiesLocalizationRepository, IStreetsLocalizationRepository streetsLocalizationRepository, IMapper mapper, IConfiguration configuration)
        {
            _shopsRepository = shopsRepository;
            _shopWorkTimesRepository = shopWorkTimesRepository;
            _citiesLocalizationRepository = citiesLocalizationRepository;
            _streetsLocalizationRepository = streetsLocalizationRepository;

            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task getInfo()
        {
            try
            {
                if (DateTime.Now.Hour == 6)
                {
                    List<WaypointsModel> waypointsModels = new List<WaypointsModel>();

                    List<Shop> shops = await _shopsRepository.getShopsForTMS();
                    List<CitiesLocalization> citiesLocalizations = await _citiesLocalizationRepository.getAll();
                    List<StreetsLocalization> streetsLocalizations = await _streetsLocalizationRepository.getAll();
                    List<ShopWorkTime> shopWorkTimes = await _shopWorkTimesRepository.getTimes();

                    List<ShopModel> shopModels = _mapper.Map<List<Shop>, List<ShopModel>>(shops);
                    List<CitiesLocalizationModel> citiesLocalizationModels = _mapper.Map<List<CitiesLocalization>, List<CitiesLocalizationModel>>(citiesLocalizations);
                    List<StreetsLocalizationModel> streetsLocalizationModels = _mapper.Map<List<StreetsLocalization>, List<StreetsLocalizationModel>>(streetsLocalizations);
                    List<ShopWorkTimeModel> shopWorkTimeModels = _mapper.Map<List<ShopWorkTime>, List<ShopWorkTimeModel>>(shopWorkTimes);

                    string date = formDate();

                    foreach (ShopModel shopModel in shopModels)
                    {

                        string city = "";
                        string street = "";

                        foreach (CitiesLocalizationModel citiesLocalizationModel in citiesLocalizationModels)
                        {
                            if (citiesLocalizationModel.CityId == shopModel.CityId && citiesLocalizationModel.LanguageId == 2)
                            {
                                city = citiesLocalizationModel.Name;
                                break;
                            }
                        }

                        foreach (StreetsLocalizationModel streetsLocalizationModel in streetsLocalizationModels)
                        {
                            if (streetsLocalizationModel.StreetId == shopModel.StreetId && streetsLocalizationModel.LanguageId == 2)
                            {
                                street = streetsLocalizationModel.Name;
                                break;
                            }
                        }

                        List<TimeWindow> timeWindows = new List<TimeWindow>();

                        foreach (ShopWorkTimeModel shopWorkTimeModel in shopWorkTimeModels)
                        {
                            if (shopWorkTimeModel.Id == shopModel.ShopWorkTimeId)
                            {
                                timeWindows.Add(new TimeWindow { startTime = shopWorkTimeModel.TuesdayFrom.ToLongTimeString(), endTime = shopWorkTimeModel.TuesdayTo.ToLongTimeString() });
                                break;
                            }
                        }

                        double? latitude = null;
                        double? longitude = null;

                        if (shopModel.Latitude != null)
                        {
                            latitude = double.Parse(shopModel.Latitude.Replace('.', ','));
                        }

                        if (shopModel.Longitude != null)
                        {
                            longitude = double.Parse(shopModel.Longitude.Replace('.', ','));
                        }

                        waypointsModels.Add(new WaypointsModel
                        {
                            id = shopModel.ShopNumber.ToString(),
                            name = $"{shopModel.ShopNumber} {city}",
                            address = $"{city}, {street}, {shopModel.Address}",
                            lat = latitude,
                            lon = longitude,
                            availabilityWindows = timeWindows.ToArray(),
                            contactPhone = shopModel.WorkPhoneNumber,
                            type = "DeliveryPoint",
                            dateRegisterNumber = date
                        });
                    }

                    request(waypointsModels);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string formDate()
        {
            DateTime dateTime = DateTime.Now;

            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;

            string date = $"{year}-";

            if (month < 10)
            {
                date += $"0{month}-";

                if (day < 10)
                {
                    date += $"0{day}";
                }
                else
                {
                    date += $"{day}";
                }
            }
            else
            {
                date += $"{month}-";
            }

            return date;
        }

        private void request(List<WaypointsModel> waypointsModels)
        {
            query("POST", waypointsModels);
            query("PUT", waypointsModels);
        }

        private void query(string method, List<WaypointsModel> waypointsModels)
        {
            WebRequest request = WebRequest.Create(_configuration["TMS:TestServer"]);

            request.Method = method;
            request.ContentType = "application/json";

            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(_configuration["TMS:Username"] + ":" + _configuration["TMS:Password"]));
            request.Headers.Add("Authorization", "Basic " + encoded);
            request.Timeout = 3600000;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonSerializer.Serialize(waypointsModels);

                streamWriter.Write(json);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStreamResponse = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStreamResponse);
                string responseFromServer = reader.ReadToEnd();
            }
        }    
    }
}
