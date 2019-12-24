using Microsoft.AspNetCore.Mvc;

namespace Petshop.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
