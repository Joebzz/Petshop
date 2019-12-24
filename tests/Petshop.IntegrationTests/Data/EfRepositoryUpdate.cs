using Petshop.Core.Entities;
using Petshop.UnitTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Petshop.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public void UpdatesItemAfterAddingIt()
        {
            // arrange
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = new PetBuilder().Name(initialName).Build();

            repository.Add(item);

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // act
            var newItem = repository.List<Pet>()
                .FirstOrDefault(i => i.Name == initialName);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newName = Guid.NewGuid().ToString();
            newItem.Name = newName;

            // Update the item
            repository.Update(newItem);
            var updatedItem = repository.List<Pet>()
                .FirstOrDefault(i => i.Name == newName);

            // assert
            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Name, updatedItem.Name);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }
    }
}
