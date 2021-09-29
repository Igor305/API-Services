using BusinessLogicLayer.Models;
using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ShopsOpeningService : IShopsOpeningService
    {
        private readonly IShopsRepository _shopsRepository;
        private readonly IConfiguration _configuration;

        public ShopsOpeningService(IShopsRepository shopsRepository, IConfiguration configuration)
        {
            _shopsRepository = shopsRepository;
            _configuration = configuration;
        }

        public async Task<ShopsOpeningResponseModel> getAllStoresOpening(string key)
        {
            ShopsOpeningResponseModel shopsOpeningResponseModel = new ShopsOpeningResponseModel();

            try
            {
                if (key != _configuration["Api:Key"])
                {
                    shopsOpeningResponseModel.Status = false;
                    shopsOpeningResponseModel.Message = "error key";

                    return shopsOpeningResponseModel;
                }

                List<Shop> shops = await _shopsRepository.getAllStoresOpening();

                foreach (Shop shop in shops)
                {
                    shopsOpeningResponseModel.shopOpeningModels.Add(new ShopOpeningModel { ShopNumber = shop.ShopNumber, OpenFrom = shop.OpenFrom });
                }

                shopsOpeningResponseModel.Status = true;
                shopsOpeningResponseModel.Message = "successfully";
            }
            catch(Exception e)
            {
                shopsOpeningResponseModel.Status = false;
                shopsOpeningResponseModel.Message = e.Message;
            }

            return shopsOpeningResponseModel;
        }
        public async Task<ShopsOpeningResponseModel> getStoresOpeningForMonth(string key, DateTime from, DateTime till)
        {
            ShopsOpeningResponseModel shopsOpeningResponseModel = new ShopsOpeningResponseModel();

            try
            {

                if (key != _configuration["Api:Key"])
                {
                    shopsOpeningResponseModel.Status = false;
                    shopsOpeningResponseModel.Message = "error key";

                    return shopsOpeningResponseModel;
                }

                List<DateTime> dateTimes = check(from, till);

                List<Shop> shops = await _shopsRepository.getStoresOpeningForMonth(dateTimes[0], dateTimes[1]);

                foreach (Shop shop in shops)
                {
                    shopsOpeningResponseModel.shopOpeningModels.Add(new ShopOpeningModel { ShopNumber = shop.ShopNumber, OpenFrom = shop.OpenFrom });
                }

                shopsOpeningResponseModel.Status = true;
                shopsOpeningResponseModel.Message = "successfully";
            }
            catch (Exception e)
            {
                shopsOpeningResponseModel.Status = false;
                shopsOpeningResponseModel.Message = e.Message;
            }

            return shopsOpeningResponseModel;
        }

        private List<DateTime> check(DateTime from, DateTime till)
        {
            DateTime dateTime = new DateTime();

            List<DateTime> dateTimes = new List<DateTime>();

            if ((from == dateTime) && (till == dateTime))
            {

            }
            else
            {
                if (from == dateTime)
                {
                    from = DateTime.Now;
                }
                if (till == dateTime)
                {
                    till = new DateTime(9999, 9, 9);
                }
            }

            dateTimes.Add(from);
            dateTimes.Add(till);

            return dateTimes;
        }
    }
}
