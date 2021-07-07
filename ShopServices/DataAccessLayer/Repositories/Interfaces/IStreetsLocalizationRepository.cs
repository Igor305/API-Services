using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IStreetsLocalizationRepository
    {
        public Task<List<StreetsLocalization>> getAll();
    }
}
