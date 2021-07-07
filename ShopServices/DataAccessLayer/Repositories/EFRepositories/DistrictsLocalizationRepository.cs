using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class DistrictsLocalizationRepository : IDistrictsLocalizationRepository
    {
        private readonly ShopsContext _shopContext;

        public DistrictsLocalizationRepository(ShopsContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<List<DistrictsLocalization>> getAll()
        {
            List<DistrictsLocalization> districtsLocalizations = await _shopContext.DistrictsLocalizations.OrderBy(x => x.DistrictId).ToListAsync();

            return districtsLocalizations;
        }
    }
}
