using Microsoft.Extensions.Options;
using MVC.Project.Extensions;
using RestSharp;

namespace MVC.Project.HttpClients;

public class RegistryPlatformClient
{
    private readonly AppSettings _appSettings;
    private HttpRequestHelper client;

    public RegistryPlatformClient(IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
        client = new HttpRequestHelper();
    }

    public async Task<RestResponse> PostRegisterInfo<T>(T body)
    {
        return await client.Request(Method.Post, _appSettings.RegistryPlatform.Uri, "register/info",
            null, body.ToJson());
    }
}
