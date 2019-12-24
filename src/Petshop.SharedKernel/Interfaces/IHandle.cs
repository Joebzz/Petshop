using System.Threading.Tasks;
using Petshop.SharedKernel;

namespace Petshop.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}