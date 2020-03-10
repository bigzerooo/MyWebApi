using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientRepository : IGenericRepository<Client,int>
    {
    }
}
