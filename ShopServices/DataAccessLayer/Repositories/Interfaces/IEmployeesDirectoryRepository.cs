using DataAccessLayer.Entities.Exchange;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeesDirectoryRepository
    {
        public Task<List<EmployeesDirectory>> getAll();
    }
}
