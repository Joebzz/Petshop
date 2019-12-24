using Petshop.Core.Entities;
using Petshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Petshop.Web
{
    public static class SeedData
    {
        public static readonly Pet Pet1 = new Pet
        {
            Name = "Rex",
            Age = 4,
            Description = "A loving dog looking for a good home."
        };

        public static readonly Pet Pet2 = new Pet
        {
            Name = "Tom",
            Age = 1,
            Description = "A loving cat looking for a good home."
        };

        public static readonly Pet Pet3 = new Pet
        {
            Name = "Archer",
            Age = 2,
            Description = "A loving lizard looking for a good home."
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.Pets.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Pets)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.Pets.Add(Pet1);
            dbContext.Pets.Add(Pet2);
            dbContext.Pets.Add(Pet3);

            dbContext.SaveChanges();
        }
    }
}
