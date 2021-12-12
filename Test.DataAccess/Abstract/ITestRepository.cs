﻿using System;
using System.Collections.Generic;
using System.Text;
using Test.Entities;
using System.Threading.Tasks;
namespace Test.DataAccess.Abstract
{
    public interface ITestRepository
    {
        Task<List<Dog>> GetDogs();
        Task<Dog> CreateDog(Dog dog);
    }
}
