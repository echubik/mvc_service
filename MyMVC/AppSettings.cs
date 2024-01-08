using System.Collections;
using System.Diagnostics;
using System.Numerics;

namespace MyMVC
{
    public class AppSettings
    {
        public RegistryPlatform RegistryPlatform { get; set; }
    }

    public class RegistryPlatform
    {
        public string Uri { get; set; }
    }
}
