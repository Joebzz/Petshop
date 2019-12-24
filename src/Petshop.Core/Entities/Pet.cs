using Petshop.Core.Events;
using Petshop.SharedKernel;

namespace Petshop.Core.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; private set; }

        public void MarkSold()
        {
            IsSold = true;
            Events.Add(new PetSoldEvent(this));
        }
    }
}
