using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Abstract;
using Test.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public async Task<Dog> GetDog(int id)
        {
            using (var testDbContext = new TestDbContext())
            {
                return await testDbContext.Dogs.FindAsync(id);
            }
        }

        public async Task<Dog> GetDogByName(string name)
        {
            using (var testDbContext = new TestDbContext())
            {
                return await testDbContext.Dogs.Where(x => x.Name == name).FirstOrDefaultAsync(); 
            }

        }
    }
}
