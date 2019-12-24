using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Petshop.Core.Entities;

namespace Petshop.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class PetDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; private set; }

        public static PetDTO FromPet(Pet item)
        {
            return new PetDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Description = item.Description,
                IsSold = item.IsSold
            };
        }
    }
}
