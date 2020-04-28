using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class ClientRepository : GenericRepository<Client, int>, IClientRepository
    {
        private readonly ISortHelper<Client> _sortHelper;
        public ClientRepository(MyDBContext myDBContext, ISortHelper<Client> sortHelper) : base(myDBContext)
        {
            _sortHelper = sortHelper;
        }
        public async Task<Client> GetClientDetailsByIdAsync(int Id)
        {
            var client = await _myDBContext.Clients
                .Include(c => c.CarHires)
                .Include(c=>c.ClientType)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
            return client;
        }
        public async Task<List<Client>> GetClientDetailsAsync()
        {
            var clients = await _myDBContext.Clients
                .Include(c => c.CarHires)
                .Include(c => c.ClientType)
                .ToListAsync();
            return clients;
        }
        public async Task<PagedList<Client>> GetAllPagesAsync(ClientParameters parameters)
        {
            var clients = FindByConditionAsync(x=>x.Id>0);//я не выдумал фильтрацию

            SearchByLastName(ref clients, parameters.LastName);

            clients = _sortHelper.ApplySort(clients, parameters);

            return await PagedList<Client>.ToPagedListAsync(clients, parameters.PageNumber, parameters.PageSize);
        }
        private void SearchByLastName(ref IQueryable<Client> clients, string lastName)
        {
            if (!clients.Any() || string.IsNullOrWhiteSpace(lastName))
                return;

            clients = clients.Where(x => x.LastName.ToLower().Contains(lastName.Trim().ToLower()));
        }
    }
}
