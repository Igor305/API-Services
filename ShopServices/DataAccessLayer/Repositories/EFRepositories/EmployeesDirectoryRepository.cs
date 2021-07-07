using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Exchange;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class EmployeesDirectoryRepository : IEmployeesDirectoryRepository
    {
        private readonly _1cExchangeContext _1cExchangeContext;

        public EmployeesDirectoryRepository (_1cExchangeContext exchangeContext)
        {
            _1cExchangeContext = exchangeContext;
        }

        public async Task<List<EmployeesDirectory>> getAll()
        {
            List<EmployeesDirectory> employeesDirectories = await _1cExchangeContext.EmployeesDirectories.ToListAsync();

            return employeesDirectories;
        }
    }
}
