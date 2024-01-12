using Microsoft.Extensions.Options;
using MVC.Project.Infrastructure.Extensions;
using MVC.Project.Infrastructure.Helpers;
using MVC.Project.Settings;
using RestSharp;

namespace MVC.Project.Infrastructure.Clients.HttpClients;

public class RegistryHttpClient : IRegistryClient
{
    private readonly RegistrySettings _settings;
    private HttpRequestHelper client;

    public RegistryHttpClient(IOptions<RegistrySettings> options)
    {
        _settings = options.Value;
        client = new HttpRequestHelper();
    }

    public async Task<RestResponse> PostRegisterInfo<T>(T body)
    {
        return await client.Request(Method.Post, _settings.Uri, "register/info",
            null, body.ToJson());
    }
}
