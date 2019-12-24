using System.Threading.Tasks;
using Petshop.SharedKernel.Interfaces;
using Petshop.SharedKernel;

namespace Petshop.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
