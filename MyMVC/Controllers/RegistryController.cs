using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.Project.Models;
using MVC.Project.Services;

namespace MVC.Project.Controllers;

[Route("/api")]
public class RegistryController : Controller
{
    private RegistryService registryService;

    public RegistryController(IOptions<AppSettings> options)
    {
        registryService = new RegistryService(options);
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
