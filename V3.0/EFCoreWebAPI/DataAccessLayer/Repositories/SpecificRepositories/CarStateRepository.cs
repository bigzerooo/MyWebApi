﻿using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarStateRepository : GenericRepository<CarState, int>, ICarStateRepository
    {
        public CarStateRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
    }
}
