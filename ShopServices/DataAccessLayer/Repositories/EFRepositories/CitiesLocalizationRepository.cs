using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class CitiesLocalizationRepository : ICitiesLocalizationRepository
    {
        private readonly ShopsContext _shopsContext;

        public CitiesLocalizationRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<List<CitiesLocalization>> getAll()
        {
            List<CitiesLocalization> citiesLocalizations = await _shopsContext.CitiesLocalizations.OrderBy(x => x.CityId).ToListAsync();

            return citiesLocalizations;
        }
    }
}
