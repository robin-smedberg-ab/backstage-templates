using Microsoft.AspNetCore.Mvc;

namespace {{ cookiecutter.dotnet_namespace }}.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PingController : ControllerBase
  {
    [HttpGet]
    public string Get()
    {
      return "Ok";
    }
  }
}
