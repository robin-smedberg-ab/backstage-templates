using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace {{ cookiecutter.dotnet_namespace }}.Services
{
  public interface IRepository
{
  Task<any> Get();
}

public class Repository : IRepository
{
  public Repository()
  {
  }

  public async Task<any> Get()
  {
    throw new NotImplementedException();
  }
}
}
