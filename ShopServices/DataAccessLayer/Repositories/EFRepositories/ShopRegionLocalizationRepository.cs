using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class ShopRegionLocalizationRepository : IShopRegionLocalizationRepository
    {
        private readonly ShopsContext _shopsContext;

        public ShopRegionLocalizationRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<List<ShopRegionLocalization>> getAll()
        {
            List<ShopRegionLocalization> shopRegionLocalizations = await _shopsContext.ShopRegionLocalizations.OrderBy(x => x.ShopRegionId).ToListAsync();

            return shopRegionLocalizations;
        }
    }
}
