using Newtonsoft.Json;

namespace TypesAPI.Models
{
    [JsonObject]
    public class Module
    {
        [JsonProperty("ID")]
        public int ID {get; set;}
        [JsonProperty("OwnerID")]
        public int? OwnerID {get; set;}
        [JsonProperty("Name")]
        public string Name {get; set;}
    }
}
