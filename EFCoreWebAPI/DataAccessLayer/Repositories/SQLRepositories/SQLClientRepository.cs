using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Helpers;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Parameters;
using DataAccessLayer.Repositories.GenericRepositories;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLClientRepository : SQLGenericRepository<Client, int>, IClientRepository
    {
        private readonly ISortHelper<Client> sortHelper;
        public SQLClientRepository(SQLDbContext myDBContext, ISortHelper<Client> sortHelper) : base(myDBContext)
        {
            this.sortHelper = sortHelper;
        }

        public async Task<PagedList<Client>> GetAllPagesAsync(ClientParameters parameters)
        {
            IQueryable<Client> clients = FindByConditionAsync(x => x.Id > 0);
            SearchByLastName(ref clients, parameters.LastName);
            clients = sortHelper.ApplySort(clients, parameters);
            return await PagedList<Client>.ToPagedListAsync(clients, parameters.PageNumber, parameters.PageSize);
        }

        //public async Task<Client> GetClientDetailsByIdAsync(int id) =>
        //    await _myDBContext.Clients
        //        .Include(c => c.CarHires)
        //        .Include(c => c.ClientType)
        //        .Where(c => c.Id == id)
        //        .FirstOrDefaultAsync();
        //public async Task<List<Client>> GetClientDetailsAsync() =>
        //    await _myDBContext.Clients
        //        .Include(c => c.CarHires)
        //        .Include(c => c.ClientType)
        //        .ToListAsync();

        private void SearchByLastName(ref IQueryable<Client> clients, string lastName)
        {
            if (!clients.Any() || string.IsNullOrWhiteSpace(lastName))
                return;
            clients = clients.Where(x => x.LastName.ToLower().Contains(lastName.Trim().ToLower()));
        }
    }
}