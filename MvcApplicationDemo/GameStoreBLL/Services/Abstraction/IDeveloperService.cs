﻿using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreBLL.Services.Abstraction
{
    public interface IDeveloperService
    {
        void AddDeveloper(Developer dev);
        IEnumerable<Developer> GetDevelopers();
        void DeleteDevelopers(string name,int id);
    }
}
