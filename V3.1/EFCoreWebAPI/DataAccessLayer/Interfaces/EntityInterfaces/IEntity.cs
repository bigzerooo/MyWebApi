using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.EntityInterfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
