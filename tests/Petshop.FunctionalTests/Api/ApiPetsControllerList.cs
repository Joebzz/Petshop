using Petshop.Core.Entities;
using Petshop.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Petshop.FunctionalTests.Api
{
    public class ApiPetsControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiPetsControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsTwoItems()
        {
            var response = await _client.GetAsync("/api/pets");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Pet>>(stringResponse).ToList();

            Assert.Equal(3, result.Count());
            Assert.Contains(result, i => i.Name == SeedData.Pet1.Name);
            Assert.Contains(result, i => i.Name == SeedData.Pet2.Name);
            Assert.Contains(result, i => i.Name == SeedData.Pet3.Name);
            //Assert.Equal(1, result.Count(a => a == SeedData.ToDoItem1));
            //Assert.Equal(1, result.Count(a => a == SeedData.ToDoItem2));
            //Assert.Equal(1, result.Count(a => a == SeedData.ToDoItem3));
        }
    }
}
