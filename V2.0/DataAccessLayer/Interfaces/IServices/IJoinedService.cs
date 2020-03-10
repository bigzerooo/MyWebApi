using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
namespace DataAccessLayer.Interfaces.IServices
{
    public interface IJoinedService
    {
        int AddJoined(Joined joined);
        void UpdateJoined(Joined client);
        void DeleteJoined(int Id);
        Joined GetJoinedById(int Id);
        IEnumerable<Joined> GetAllJoined();
    }
}
