using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVC.Project.Models;

public class RegistryRequestBody
{
    [BindRequired]
    public List<string> IdPat { get; set; }

    [BindRequired]
    public List<string> Diagnosis { get; set; }
}

public class RegistryResponseBody
{
    public string Name { get; set; }

    public string Url { get; set; }

    public string[] Diagnosis { get; set; }
}
