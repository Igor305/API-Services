using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ITradeClientFrameService
    {
        public Task getImagePerDay(int stockId);
        public Task getImagePerMonth(int stockId);
        public Task getImagePerForecast(int stockId);
        public Task getAllInOneImage(int stockId);
    }
}
