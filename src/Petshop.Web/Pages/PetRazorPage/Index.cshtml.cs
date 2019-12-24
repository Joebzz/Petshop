using Petshop.Core.Entities;
using Petshop.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Petshop.Web.Pages.PetRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        public List<Pet> Pets { get; set; }

        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Pets = _repository.List<Pet>();
        }
    }
}
