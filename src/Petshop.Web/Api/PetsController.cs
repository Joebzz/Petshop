using Petshop.Core.Entities;
using Petshop.SharedKernel.Interfaces;
using Petshop.Web.ApiModels;
using Petshop.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Petshop.Web.Api
{
    public class PetsController : BaseApiController
    {
        private readonly IRepository _repository;

        public PetsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/pets
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List<Pet>()
                            .Select(PetDTO.FromPet);
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = PetDTO.FromPet(_repository.GetById<Pet>(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public IActionResult Post([FromBody] PetDTO item)
        {
            var pet = new Pet()
            {
                Name = item.Name,
                Age = item.Age,
                Description = item.Description
            };
            _repository.Add(pet);
            return Ok(PetDTO.FromPet(pet));
        }

        [HttpPatch("{id:int}/sold")]
        public IActionResult Sold(int id)
        {
            var pet = _repository.GetById<Pet>(id);
            pet.MarkSold();
            _repository.Update(pet);

            return Ok(PetDTO.FromPet(pet));
        }
    }
}
