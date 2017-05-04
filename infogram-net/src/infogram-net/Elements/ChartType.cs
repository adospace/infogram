

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace infogram_net.Elements
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChartType
    {
        bar,
        pie
    }
}