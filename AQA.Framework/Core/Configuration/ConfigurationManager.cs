using System.Net;
using AQA.Blank.Core.Configuration.Models;
using AQA.Blank.Core.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AQA.Blank.Core.Configuration;

public class ConfigurationManager
{
    public static IConfiguration Configuration =>
        new ConfigurationBuilder().AddJsonFile(PathHelper.GetAssemblyFile(Constants.ConfigurationFileName)).Build();
    
    [JsonProperty(nameof(RunSettings))]
    public static RunSettings RunSettings { get; set; }
    
    [JsonProperty(nameof(BrowserOptions))]
    public static BrowserOptions BrowserOptions { get; set; }
    
    [JsonProperty(nameof(UseProxy))]
    public static bool UseProxy { get; set; }
    
    [JsonProperty(nameof(Proxy))]
    public static Proxy Proxy { get; set; }
    
    public static IWebProxy DefaultProxy => new WebProxy
    {
        Address = new Uri($"http://{Proxy.Address}:{Proxy.Port}"),
        BypassProxyOnLocal = true
    };

    static ConfigurationManager()
    {
        var path = PathHelper.GetAssemblyFile(Constants.ConfigurationFileName);
        JsonConvert.DeserializeObject<ConfigurationManager>(File.ReadAllText(path));
    }
}
