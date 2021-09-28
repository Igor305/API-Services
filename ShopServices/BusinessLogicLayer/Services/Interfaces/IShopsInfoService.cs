using BusinessLogicLayer.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IShopsInfoService
    {
        public Task<ShopsInfoResponseModel> getInfoForAllShops(string key);
        public Task<ShopsInfoResponseModel> getInfoForShopsByStatus(string key, int statusId);
    }
}
