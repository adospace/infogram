using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net.Elements
{
    public class H2 : Element
    {
        public H2() { Type = ElementType.h2; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
