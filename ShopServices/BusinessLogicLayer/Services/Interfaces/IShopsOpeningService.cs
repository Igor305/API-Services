using BusinessLogicLayer.Models.Response;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IShopsOpeningService
    {
        public Task<ShopsOpeningResponseModel> getAllStoresOpening(string key);
        public Task<ShopsOpeningResponseModel> getStoresOpeningForMonth(string key, DateTime from, DateTime till);
    }
}
