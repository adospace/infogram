using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net
{
    public class Infographic
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "theme_id")]
        public int ThemeId { get; set; }
        [JsonProperty(PropertyName = "published")]
        public bool Published { get; set; }
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string ThumbnailUrl { get; set; }
        [JsonProperty(PropertyName = "date_modified")]
        public DateTime DateModified { get; set; }
        [JsonProperty(PropertyName = "user_profile")]
        public string UserProfile { get; set; }
        [JsonProperty(PropertyName = "publish_mode")]
        public string PublishMode { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "embed_responsive")]
        public string EmbedResponsive { get; set; }
        [JsonProperty(PropertyName = "embed_async")]
        public string EmbedAsync { get; set; }
    }
}
