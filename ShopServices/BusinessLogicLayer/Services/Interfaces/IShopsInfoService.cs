using BusinessLogicLayer.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IShopsInfoService
    {
        public Task<ShopsInfoResponseModel> getInfoForAllShops();
        public Task<ShopsInfoResponseModel> getInfoForShopsByStatus(int statusId);
    }
}
