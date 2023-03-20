using AQA.Blank.Core;
using AQA.Blank.Core.Configuration;
using AQA.Blank.Core.Factories;
using AQA.Blank.Core.Utils;

namespace AQA.Blank.Framework.Services;

public class PageOpenService
{
    private Browser Browser => BrowserFactory.GetBrowser();

    public void OpenEvent(string url, string id)
    {
        Reporter.Info("Go to event page.");
        Browser.Open($"{ConfigurationManager.RunSettings.Url}/EDP/Event/Index/{id}");
    }
    
    public void OpenHomePage()
    {
        var url = ConfigurationManager.RunSettings.Url;
        Reporter.Info($"Open Home page - {url}");
        Browser.Open(url);
    }
}