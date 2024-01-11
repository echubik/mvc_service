using Microsoft.AspNetCore.Mvc;
using MVC.Project.Infrastructure.Services;
using MVC.Project.Models;

namespace MVC.Project.Controllers;

[Route("/api")]
public class RegistryController : Controller
{
    private RegistryService registryService;

    public RegistryController(RegistryService registryService)
    {
        this.registryService = registryService;
    }

    [HttpPost("register/info")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<RegistryResponseBody[]>> RegisterInfo([FromBody] RegistryRequestBody registryRequestBody)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await registryService.GetRegisterInfo(registryRequestBody);

    }
}
