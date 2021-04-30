using DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IitExecutionPlanShopRepository
    {
        public Task<ItExecutionPlanShop> getInfoForStockId(int stockId);
    }
}
