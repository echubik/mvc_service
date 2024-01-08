using Newtonsoft.Json;

namespace MyMVC.Helpers
{
    public static class CustomExtensions
    {
        public static string ToJson<T>(this T value)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(value, settings);
        }

        public static T ToCertType<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
