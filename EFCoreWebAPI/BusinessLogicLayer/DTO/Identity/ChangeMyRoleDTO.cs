using DataAccessLayer.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO.Identity
{
    class ChangeMyRoleDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<MyRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeMyRoleDTO()
        {
            AllRoles = new List<MyRole>();
            UserRoles = new List<string>();
        }
    }
}
