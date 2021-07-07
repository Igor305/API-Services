using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IShopRegionLocalizationRepository
    {
        public Task<List<ShopRegionLocalization>> getAll();
    }
}
