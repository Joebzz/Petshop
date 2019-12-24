using Petshop.Core.Entities;
using Petshop.UnitTests;
using System;
using Xunit;

namespace Petshop.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public void DeletesItemAfterAddingIt()
        {
            // arrange
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = new PetBuilder().Name(initialName).Build();
            repository.Add(item);

            // act
            repository.Delete(item);

            // assert
            Assert.DoesNotContain(repository.List<Pet>(),
                i => i.Name == initialName);
        }
    }
}
