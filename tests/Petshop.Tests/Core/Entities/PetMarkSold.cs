using Petshop.Core.Entities;
using Petshop.Core.Events;
using System.Linq;
using Xunit;

namespace Petshop.UnitTests.Core.Entities
{
    public class PetMarkSold
    {
        [Fact]
        public void SetsIsSoldToTrue()
        {
            // arrange
            var item = new PetBuilder()
                .WithDefaultValues()
                .Description("")
                .Build();

            // act
            item.MarkSold();

            // assert
            Assert.True(item.IsSold);
        }

        [Fact]
        public void RaisesToDoItemCompletedEvent()
        {
            // arrange
            var item = new PetBuilder().Build();

            // act
            item.MarkSold();

            // assert
            Assert.Single(item.Events);
            Assert.IsType<PetSoldEvent>(item.Events.First());
        }
    }
}
