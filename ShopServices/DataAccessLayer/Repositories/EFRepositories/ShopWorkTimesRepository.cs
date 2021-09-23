using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class ShopWorkTimesRepository : IShopWorkTimesRepository
    {
        private readonly ShopsContext _shopsContext;

        public ShopWorkTimesRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<List<ShopWorkTime>> getTimes()
        {
            List<ShopWorkTime> shopWorkTimes = await _shopsContext.ShopWorkTimes.ToListAsync();

            return shopWorkTimes;
        }
    }
}
