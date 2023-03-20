using Newtonsoft.Json;

namespace AQA.Blank.Core.Configuration.Models;

public class RunSettings
{
    [JsonProperty(nameof(User))]
    public User User { get; set; }

    [JsonProperty(nameof(EventName))]
    public string EventName { get; set; }

    [JsonProperty(nameof(Url))]
    public string Url { get; set; }
}