﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.DataBase
{
    public class InMemoryDataBase
    {
        public List<User> Users = new();
        public List<Project> Projects = new();
        public List<DomainTask> Tasks = new();

    }
}
