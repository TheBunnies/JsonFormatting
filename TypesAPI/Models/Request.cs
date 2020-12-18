using Newtonsoft.Json;
using System.Collections.Generic;

namespace TypesAPI.Models
{
    [JsonObject]
    public sealed class Request
    {
        [JsonProperty("Modules")]
        public List<Module> Modules {get; set;}
        [JsonProperty("Types")]
        public List<Type> Types {get; set;}
    }
}
