using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class NewRepository : GenericRepository<New,int>, INewRepository
    {
        public NewRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
    }
}
