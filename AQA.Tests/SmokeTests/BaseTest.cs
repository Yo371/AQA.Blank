using AQA.Blank.Core.Factories;
using AQA.Blank.Framework.Pages.Interfaces;
using AQA.Blank.Framework.Services;

namespace AQA.Tests.SmokeTests;

public class BaseTest
{
    protected IHomePage HomePage => Get<IHomePage>();
    
    protected ILoginPage LoginPage => Get<ILoginPage>();
    protected LoginService LoginService => Get<LoginService>();
    
    protected T Get<T>() where T : class => ObjectFactory.Get<T>()!;
    

    [OneTimeTearDown]
    public void CloseBrowser() =>  BrowserFactory.GetBrowser().CloseBrowser();
}