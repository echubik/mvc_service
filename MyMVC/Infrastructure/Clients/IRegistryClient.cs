using RestSharp;

namespace MVC.Project.Infrastructure.Clients
{
    public interface IRegistryClient
    {
        Task<RestResponse> PostRegisterInfo<T>(T body);
    }
}
