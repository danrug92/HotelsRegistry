using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

///summary
///Si definiscono le impostazioni di serializzazione dei json
///Controllo gestione metadati
///Gestione del formato delle date in UTC
///!summary
namespace Common.Serializer
{
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
        };
    }
    
}
