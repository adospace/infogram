using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net.Elements
{
    public abstract class Element
    {
        [JsonProperty(PropertyName = "type")]
        public ElementType Type { get; set; }

    }

    
}
