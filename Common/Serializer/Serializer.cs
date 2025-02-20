using Newtonsoft.Json;

namespace Common.Serializer
{
    public static class Serializer
    {
        public static string ToJson<T>(this T obj) => JsonConvert.SerializeObject(obj, Converter.Settings);
    }
}
