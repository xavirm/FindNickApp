using System;
using Newtonsoft.Json;

namespace reto8
{
    public class Nick
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string sku { get; set; }

        [JsonProperty(PropertyName = "cost")]
        public decimal cost { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string location { get; set; }
    }

    public class NickWrapper : Java.Lang.Object
    {
        public NickWrapper(Nick nick)
        {
            Nick = nick;
        }

        public Nick Nick { get; private set; }
    }
}

