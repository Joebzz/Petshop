using Petshop.Core.Entities;

namespace Petshop.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class PetBuilder
    {
        private Pet _pet = new Pet();

        public PetBuilder Id(int id)
        {
            _pet.Id = id;
            return this;
        }

        public PetBuilder Name(string name)
        {
            _pet.Name = name;
            return this;
        }

        public PetBuilder Age(int age)
        {
            _pet.Age = age;
            return this;
        }

        public PetBuilder Description(string description)
        {
            _pet.Description = description;
            return this;
        }

        public PetBuilder WithDefaultValues()
        {
            _pet = new Pet() { Id = 1, Name = "Test Pet", Age = 1, Description = "Test Description" };

            return this;
        }

        public Pet Build() => _pet;
    }
}
