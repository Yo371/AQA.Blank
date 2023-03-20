using Newtonsoft.Json;

namespace AQA.Blank.Core.Configuration.Models;

public class User
{
    [JsonProperty(nameof(Name))]
    public string Name { get; set; }
    
    [JsonProperty(nameof(Password))]
    public string Password { get; set; }
    
    [JsonProperty(nameof(Email))]
    public string Email { get; set; }
    
    [JsonProperty(nameof(Surname))]
    public string Surname { get; set; }
}