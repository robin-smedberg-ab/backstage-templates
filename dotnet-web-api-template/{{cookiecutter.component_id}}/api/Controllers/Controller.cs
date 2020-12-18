using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using {{ cookiecutter.dotnet_namespace }}.Services

namespace {{ cookiecutter.dotnet_namespace }}.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class Controller : ControllerBase
  {
    private readonly IService _service;

    public Controller(IService service)
    {
      _service = service;
    }

    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _service.Get();
        return new OkObjectResult(result);
      }
      catch (System.Exception e)
      {
        return BadRequest("Error reading fetching data");
      }
    }
  }
}
