using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDistrictsLocalizationRepository
    {
        public Task<List<DistrictsLocalization>> getAll();
    }
}
