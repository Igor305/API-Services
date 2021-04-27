using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ShopsService: IShopsService
    {
        private readonly IShopsRepository _shopsRepository;

        public ShopsService(IShopsRepository shopsRepository)
        {
            _shopsRepository = shopsRepository;
        }

        public async Task<List<ShopsResponseModel>> getAllStoresOpening()
        {
            List<ShopsResponseModel> shopsResponseModels = new List<ShopsResponseModel>();

            List<Shop> shops = await _shopsRepository.getAllStoresOpening();

            foreach(Shop shop in shops)
            {
                shopsResponseModels.Add(new ShopsResponseModel { ShopNumber = shop.ShopNumber, OpenFrom = shop.OpenFrom });
            }

            return shopsResponseModels;
        }
        public async Task<List<ShopsResponseModel>> getStoresOpeningForMonth(DateTime from, DateTime till)
        {
            List<DateTime> dateTimes = check(from, till);

            List<ShopsResponseModel> shopsResponseModels = new List<ShopsResponseModel>();

            List<Shop> shops = await _shopsRepository.getStoresOpeningForMonth(dateTimes[0], dateTimes[1]);

            foreach (Shop shop in shops)
            {
                shopsResponseModels.Add(new ShopsResponseModel { ShopNumber = shop.ShopNumber, OpenFrom = shop.OpenFrom });
            }

            return shopsResponseModels;
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
