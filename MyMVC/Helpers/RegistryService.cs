using Microsoft.Extensions.Options;
using MyMVC;
using MyMVC.Helpers;
using MyMVC.Models;

namespace Service.Helpers;

public class RegistryService
{
    private readonly RegistryPlatformClient registryPlatform;

    public RegistryService(IOptions<AppSettings> options)
    {
        registryPlatform = new RegistryPlatformClient(options);
    }

    public async Task<RegistryResponseBody[]> GetRegisterInfo(RegistryRequestBody registryRequestBody)
    {
        var response = await registryPlatform.PostRegisterInfo(registryRequestBody);

        var fakeResponse = new RegistryResponseBody()
        {
            Name = "test",
            Diagnosis = new[] { "U07.2", "A15.1", "B20.2" },
            Url = "http://test.zdrav.netrika.ru/release3/registry_platform_ui/diseaseCard/2085/5f9f3d39-ee56-45fd-820b-928999b040b8/integralDiseaseEpicrisis?fromIemkPortal=true"
        };

        return (response.StatusCode == System.Net.HttpStatusCode.OK) && !string.IsNullOrEmpty(response.Content)
            ? response.Content.ToCertType<RegistryResponseBody[]>()
            : new[] { fakeResponse };
    }
}
