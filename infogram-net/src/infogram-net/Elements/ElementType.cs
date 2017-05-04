﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net.Elements
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ElementType
    {
        h1,
        h2,
        body,
        quote,
        separator,
        chart,
        map,
        facts_and_figures,
    }
}
