using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IShopWorkTimesRepository
    {
        public Task<List<ShopWorkTime>> getTimes();
    }
}
