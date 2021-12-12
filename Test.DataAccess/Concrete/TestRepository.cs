using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Abstract;
using Test.Entities;
using Microsoft.EntityFrameworkCore;
namespace Test.DataAccess.Concrete
{
    public class TestRepository : ITestRepository
    {
        public  async Task<Dog> CreateDog(Dog dog)
        {
            using (var testDbContext=new TestDbContext())
            {
                testDbContext.Dogs.Add(dog);
                await testDbContext.SaveChangesAsync();
                return dog;
            }
        }

        public async Task<List<Dog>> GetDogs()
        {
            using (var testDbContext=new TestDbContext())
            {
                return await testDbContext.Dogs.ToListAsync();
            }
        }
    }
}
