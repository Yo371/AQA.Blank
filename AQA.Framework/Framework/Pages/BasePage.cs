using AQA.Blank.Core;
using AQA.Blank.Core.Factories;
using AQA.Blank.Framework.Pages.Interfaces;
using AQA.Blank.Framework.Pages.PageParts;

namespace AQA.Blank.Framework.Pages;

public interface IPage
{
    IHeader Header { get; }
}

public abstract class BasePage<T> : Loadable<T>, IPage where T : Loadable<T>
{
    protected Browser Browser => BrowserFactory.GetBrowser();

    public IHeader Header => MenuToggle.IsDisplayed
        ? GetPart<MinimizedHeader>("xpathOrCss")
        : GetPart<MaximizedHeader>(".xpathOrCss");

    private IElement MenuToggle => GetElement("xpathOrCss");

    protected BasePage()
    {
        Load();
    }

    protected IElement GetElement(string selector) => Browser.GetElement(selector);

    protected List<IElement> GetElements(string selector) => Browser.GetElements(selector);

    protected T GetPart<T>(string selector) where T : BasePagePart<T> => Browser.GetPart<T>(selector);

    protected List<T> GetParts<T>(string selector) where T : BasePagePart<T> => Browser.GetParts<T>(selector);
}