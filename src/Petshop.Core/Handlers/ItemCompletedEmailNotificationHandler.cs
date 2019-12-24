using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Petshop.Core.Events;
using Petshop.SharedKernel.Interfaces;

namespace Petshop.Core.Services
{
    public class ItemCompletedEmailNotificationHandler : IHandle<ToDoItemCompletedEvent>
    {
        public Task Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
            return Task.CompletedTask;
        }
    }
}
