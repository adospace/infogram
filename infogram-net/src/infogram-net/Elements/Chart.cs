using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net.Elements
{
    public class Chart : Element
    {
        public Chart() { Type = ElementType.chart; }

        [JsonProperty(PropertyName = "chart_type")]
        public ChartType ChartType { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object[] Data { get; set; }

        [JsonProperty(PropertyName = "colors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Colors { get; set; }

        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

    }
}
