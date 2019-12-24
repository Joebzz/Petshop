using Petshop.Core.Entities;
using Petshop.UnitTests;
using System.Linq;
using Xunit;

namespace Petshop.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {

        [Fact]
        public void AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var item = new PetBuilder().Build();

            repository.Add(item);

            var newItem = repository.List<Pet>().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
