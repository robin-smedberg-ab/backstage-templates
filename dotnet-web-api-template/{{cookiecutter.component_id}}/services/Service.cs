using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace {{ cookiecutter.dotnet_namespace }}.Services
{
  public interface IService
{
  Task<any> Get();
}

public class Service : IService
{
  private readonly IRepository _repository;
  public Service(IRepository repository)
  {
    _repository = repository;
  }

  public async Task<dynamic> Get()
  {
    return _repository.Get();
  }
}
}
