using Petshop.Core.Entities;
using Petshop.Core.Events;
using Petshop.Infrastructure;
using Petshop.Infrastructure.DomainEvents;
using Xunit;

namespace Petshop.UnitTests.Core.DomainEvents
{
    public class DomainEventDispatcherShould
    {
        [Fact]
        public void NotReturnAnEmptyListOfAvailableHandlers()
        {
            // arrange
            var container = ContainerSetup.BaseAutofacInitialization();

            var domainEventDispatcher = new DomainEventDispatcher(container);
            var petSoldEvent = new PetSoldEvent(new Pet());
            
            // act
            var handlersForEvent = domainEventDispatcher.GetWrappedHandlers(petSoldEvent);

            // assert
            Assert.NotEmpty(handlersForEvent);
        }
    }
}
