using System.Collections.ObjectModel;
using AQA.Blank.Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace AQA.Blank.Core;

public class Browser : ISearchContext
{
    private IWebDriver _webDriver;
    
    private List<string> ChromeArguments => new List<string>
    {
        "--use-fake-ui-for-media-stream",
        "--no-sandbox",
        "--ignore-certificate-errors",
        "--disable-backgrounding-occluded-windows"
    };
    
    private List<string> ArgumentsList => new List<string>
    {
        $"--proxy-server=http://{ConfigurationManager.Proxy.Address}:{ConfigurationManager.Proxy.Port}",
        $"--proxy-bypass-list=\"{string.Join(";", ConfigurationManager.Proxy.BypassAddresses)}\""
    };
    
    private Dictionary<string, object> ChromeCapabilities => new Dictionary<string, object>
    {
        { CapabilityType.AcceptSslCertificates, true },
        { CapabilityType.AcceptInsecureCertificates, true }
    };
    
    public string Title => _webDriver.Title;

    public Browser()
    {
        _webDriver = SetUpBrowser();
    }

    public void Open(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public void CloseBrowser()
    {
        _webDriver.Quit();
    }

    public IWebElement FindElement(By by) => _webDriver.FindElement(by);

    public ReadOnlyCollection<IWebElement> FindElements(By by) => _webDriver.FindElements(by);

    public void ScrollToElement(IWebElement webElement) =>
        ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);",
            webElement);

    public void MoveToElement(IWebElement webElement) =>
        new Actions(_webDriver).MoveToElement(webElement).Build().Perform();

    public string TakeScreenshot()
    {
        if (!Directory.Exists(Constants.ScreenshotsPath)) Directory.CreateDirectory(Constants.ScreenshotsPath);

        var screenshotFileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".jpeg";

        var fullPath = Path.Combine(Constants.ScreenshotsPath, screenshotFileName);

        ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(fullPath, ScreenshotImageFormat.Jpeg);

        return fullPath;
    }

    private IWebDriver SetUpBrowser()
    {
        var browserType = ConfigurationManager.BrowserOptions.BrowserType;
        var driver = browserType switch
        {
            "Chrome" => GetChromeDriver(),
            "Edge" => GetEdgeDriver(),
            _ => throw new ArgumentException($"Cannot identify browser type: {browserType}")
        };

        var pageLoadTimeout = ConfigurationManager.BrowserOptions.PageLoadTimeOutMs;
        var jsTimeout = ConfigurationManager.BrowserOptions.AsyncJsTimeoutMs;
        var implicitTimeout = ConfigurationManager.BrowserOptions.ImplicitWaitTimeOutMs;

        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(pageLoadTimeout);
        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMilliseconds(jsTimeout);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitTimeout);
        return driver;
    }

    private IWebDriver GetChromeDriver()
    {
        var options = new ChromeOptions();
        var driverManager = new DriverManager();

        if (ConfigurationManager.UseProxy)
        {
            options.AddArguments(ArgumentsList);
            driverManager = driverManager.WithProxy(ConfigurationManager.DefaultProxy);
        }
        
        ChromeCapabilities.ToList()
            .ForEach(pair => options.AddAdditionalOption(pair.Key, pair.Value));
        options.AddArguments(ChromeArguments);
        
        driverManager.SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        return new ChromeDriver(options);
    }

    private IWebDriver GetEdgeDriver()
    {
        var options = new EdgeOptions();
        var driverManager = new DriverManager();;

        if (ConfigurationManager.UseProxy)
        {
            options.AddArguments(ArgumentsList);
            driverManager = driverManager.WithProxy(ConfigurationManager.DefaultProxy);
        }

        driverManager.SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
        return new EdgeDriver(options);
    }
}