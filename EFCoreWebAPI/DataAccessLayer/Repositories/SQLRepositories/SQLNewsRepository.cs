using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLNewsRepository : SQLGenericRepository<News>, INewsRepository
    {
        public SQLNewsRepository(SQLDbContext myDBContext) : base(myDBContext) { }
    }
}