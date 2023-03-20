using Newtonsoft.Json;

namespace AQA.Blank.Core.Configuration.Models;

public class Proxy
{
    [JsonProperty(nameof(Address))]
    public string Address { get; set; }

    [JsonProperty(nameof(Port))]
    public int Port { get; set; }

    [JsonProperty(nameof(BypassAddresses))]
    public List<string> BypassAddresses { get; set; }
}