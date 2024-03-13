using Microsoft.AspNetCore.Mvc;
using MVC.Project.Infrastructure.Services;
using MVC.Project.Models;

namespace MVC.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistryController : ControllerBase
{
    private readonly RegistryService _registryService;

    public RegistryController(RegistryService registryService)
    {
        _registryService = registryService;
    }

    [HttpPost("register/info")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<RegistryResponseBody[]>> RegisterInfo([FromBody] RegistryRequestBody registryRequestBody)
        =>  await _registryService.GetRegisterInfo(registryRequestBody);
}
