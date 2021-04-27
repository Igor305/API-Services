using DataAccessLayer.Entities.Shops;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IShopsRepository
    {
        public Task<List<Shop>> getAllStoresOpening();
        public Task<List<Shop>> getStoresOpeningForMonth(DateTime from, DateTime till);
    }
}
