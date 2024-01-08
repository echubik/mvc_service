using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyMVC.Models
{
    public class RegistryRequestBody
    {
        [BindRequired]
        public List<string> idPat { get; set; }

        [BindRequired]
        public List<string> diagnosis { get; set; }
    }

    public class RegistryResponseBody
    {
        public string name { get; set; }

        public string url { get; set; }

        public string[] diagnosis { get; set; }
    }
}
