using Petshop.Core.Entities;
using Petshop.SharedKernel;

namespace Petshop.Core.Events
{
    public class PetSoldEvent : BaseDomainEvent
    {
        public Pet SoldPet { get; set; }

        public PetSoldEvent(Pet soldPet)
        {
            SoldPet = soldPet;
        }
    }
}