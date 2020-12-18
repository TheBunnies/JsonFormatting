using Newtonsoft.Json;
using System.Collections.Generic;


namespace TypesAPI.Models
{
    public class FormattedType
    {
        [JsonProperty("ID")]
        public int ID {get; set;}
        [JsonProperty("Children")]
        public List<FormattedType> Children {get; set;}
        [JsonProperty("Name")]
        public string Name {get; set;}
        [JsonProperty("Icon")]
        public string Icon {get; set;}
        [JsonProperty("ModuleID")]
        public int? ModuleID {get; set;}
    }
}
