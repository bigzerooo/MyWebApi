using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class NewRepository : SQLGenericRepository<New>, INewRepository
    {
        public NewRepository(SQLDbContext myDBContext) : base(myDBContext) { }
    }
}