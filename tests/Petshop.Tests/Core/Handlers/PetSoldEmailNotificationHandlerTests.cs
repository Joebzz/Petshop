using Petshop.Core.Entities;
using Petshop.Core.Events;
using Petshop.Core.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Petshop.UnitTests.Core.Entities
{
    public class PetSoldEmailNotificationHandlerTests
    {
        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            // arrange
            var handler = new PetSoldEmailNotificationHandler();

            // act 
            // assert
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null));
        }

        [Fact]
        public async Task DoesNothingGivenEventInstance()
        {
            // arrange
            var handler = new PetSoldEmailNotificationHandler();

            // act 
            // assert
            await handler.Handle(new PetSoldEvent(new Pet()));
        }
    }
}
