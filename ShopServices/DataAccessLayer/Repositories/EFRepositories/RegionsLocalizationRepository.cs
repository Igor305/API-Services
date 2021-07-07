using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class RegionsLocalizationRepository : IRegionsLocalizationRepository
    {
        private readonly ShopsContext _shopContext;

        public RegionsLocalizationRepository(ShopsContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<List<RegionsLocalization>> getAll()
        {
            List<RegionsLocalization> regionsLocalizations = await _shopContext.RegionsLocalizations.OrderBy(x => x.RegionId).ToListAsync();

            return regionsLocalizations;
        }
    }
}
