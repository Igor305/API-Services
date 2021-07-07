using BusinessLogicLayer.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IShopsOpeningService
    {
        public Task<List<ShopsResponseModel>> getAllStoresOpening();
        public Task<List<ShopsResponseModel>> getStoresOpeningForMonth(DateTime from, DateTime till);
    }
}
