using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ICitiesLocalizationRepository
    {
        public Task<List<CitiesLocalization>> getAll();
    }
}
