using Petshop.Core.Entities;
using Petshop.SharedKernel.Interfaces;
using System.Linq;

namespace Petshop.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository petRepository)
        {
            if (petRepository.List<Pet>().Count() >= 5) return 0;

            petRepository.Add(new Pet
            {
                Name = "Rex",
                Description = "Rex is a loving dog."
            });
            petRepository.Add(new Pet
            {
                Name = "Steve",
                Description = "Steve is a loving cat."
            });
            petRepository.Add(new Pet
            {
                Name = "Archer",
                Description = "Archer is a loving lizard."
            });

            return petRepository.List<Pet>().Count;
        }
    }
}
