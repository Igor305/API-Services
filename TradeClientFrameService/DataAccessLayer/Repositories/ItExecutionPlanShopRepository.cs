using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ItExecutionPlanShopRepository : IitExecutionPlanShopRepository
    {
        private readonly AvroraContext _avroraContext;

        public ItExecutionPlanShopRepository( AvroraContext avroraContext)
        {
            _avroraContext = avroraContext;
        }

        public async Task<ItExecutionPlanShop> getInfoForStockId(int stockId)
        {
            ItExecutionPlanShop itExecutionPlanShop = await _avroraContext.ItExecutionPlanShops.Where(x => x.StockId == stockId).FirstOrDefaultAsync();

            return itExecutionPlanShop;
        }
    }
}
