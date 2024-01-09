using RestSharp;

namespace MyMVC.Helpers;

public class HttpRequestHelper
{
    public async Task<RestResponse> Request(Method method, string host, string path,
        string authorization, string body, string contentType = null)
    {
        var client = new RestClient(host);
        var request = new RestRequest(path, method);

        request.AddHeader("Content-Type",
            !string.IsNullOrEmpty(contentType)
                ? contentType
                : "application/json; charset=utf-8");

        if (!string.IsNullOrEmpty(authorization))
            request.AddHeader("Authorization", authorization);

        switch (method)
        {
            case Method.Post:
            case Method.Put:
                request.AddStringBody(body, DataFormat.Json);
                break;
        }

        return await client.ExecuteAsync(request);
    }
}
