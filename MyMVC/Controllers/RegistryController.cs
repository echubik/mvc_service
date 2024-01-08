using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyMVC.Helpers;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    [Route("/api")]
    public class RegistryController : Controller
    {
        private RegistryPlatformClient registryPlatform;

        public RegistryController(IOptions<AppSettings> options)
        {
            registryPlatform = new RegistryPlatformClient(options);
        }

        [HttpPost("register/info")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RegistryResponseBody[]>> RegisterInfo([FromBody] RegistryRequestBody registryRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await registryPlatform.PostRegisterInfo(registryRequestBody);

            var fakeResponse = new RegistryResponseBody()
            {
                name = "test",
                diagnosis = new[] { "U07.2", "A15.1", "B20.2" },
                url = "http://test.zdrav.netrika.ru/release3/registry_platform_ui/diseaseCard/2085/5f9f3d39-ee56-45fd-820b-928999b040b8/integralDiseaseEpicrisis?fromIemkPortal=true"
            };

            return (response.StatusCode == System.Net.HttpStatusCode.OK) && !string.IsNullOrEmpty(response.Content)
                ? response.Content.ToCertType<RegistryResponseBody[]>()
                : new[] { fakeResponse };
        }
    }
}
