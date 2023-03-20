namespace AQA.Blank.Core.Factories;

public static class BrowserFactory
{
    private static readonly ThreadLocal<Browser> Browser = new();

    public static Browser GetBrowser() => Browser.Value ?? SetUpBrowser();

    private static Browser SetUpBrowser()
    {
        Browser.Value = ObjectFactory.Get<Browser>()!;
        return Browser.Value;
    }
}