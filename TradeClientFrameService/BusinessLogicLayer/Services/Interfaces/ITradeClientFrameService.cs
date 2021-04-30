using BusinessLogicLayer.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ITradeClientFrameService
    {
        public Task<ImagesReposnseModel> getImages(int stockId);
    }
}
