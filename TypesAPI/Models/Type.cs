using Newtonsoft.Json;

namespace TypesAPI.Models
{
    [JsonObject]
    public class Type
    {
        [JsonProperty("ID")]
        public int ID {get; set;}
        [JsonProperty("OwnerID")]
        public int? OwnerID {get; set;}
        [JsonProperty("Name")]
        public string Name {get; set;}
        [JsonProperty("Icon")]
        public string Icon {get; set;}
        [JsonProperty("ModuleID")]
        public int? ModuleID {get; set;}

    }
}
