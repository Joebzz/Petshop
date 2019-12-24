using Petshop.Core;
using Petshop.Core.Entities;
using Petshop.SharedKernel.Interfaces;
using Petshop.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Petshop.Web.Controllers
{
    public class PetController : Controller
    {
        private readonly IRepository _repository;

        public PetController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var items = _repository.List<Pet>()
                            .Select(PetDTO.FromPet);
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
