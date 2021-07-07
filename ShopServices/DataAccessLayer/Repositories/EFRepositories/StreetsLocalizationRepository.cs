using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class StreetsLocalizationRepository : IStreetsLocalizationRepository
    {
        private readonly ShopsContext _shopsContext;

        public StreetsLocalizationRepository (ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<List<StreetsLocalization>> getAll()
        {
            List<StreetsLocalization> streetsLocalizations = await _shopsContext.StreetsLocalizations.OrderBy(x => x.StreetId).ToListAsync();

            return streetsLocalizations;
        }
    }
}
