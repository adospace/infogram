using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net.Elements
{
    public class H1 : Element
    {
        public H1() { Type = ElementType.h1; }

        [JsonProperty(PropertyName ="text")]
        public string Text { get; set; }
    }
}
