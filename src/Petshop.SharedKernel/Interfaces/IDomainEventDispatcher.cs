using System.Threading.Tasks;
using Petshop.SharedKernel;

namespace Petshop.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}