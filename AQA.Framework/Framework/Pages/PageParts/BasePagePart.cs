using AQA.Blank.Core.Factories;
using AQA.Blank.Framework.Pages.Interfaces;
using OpenQA.Selenium;

namespace AQA.Blank.Framework.Pages.PageParts;

public interface IPagePart
{
}

public abstract class BasePagePart<T> :  Loadable<T>, IPagePart where T : Loadable<T>
{
    protected IElement WrappedElement => ObjectFactory.Get<IElement>(_findFunc);
    
    private readonly Func<IWebElement> _findFunc;

    protected BasePagePart(Func<IWebElement> findFunc)
    {
        _findFunc = findFunc;
        Load();
    }
    
    protected IElement GetElement(string selector) => WrappedElement.GetElement(selector);
    
    protected List<IElement> GetElements(string selector) => WrappedElement.GetElements(selector);
    protected T GetPart<T>(string selector) where T : IPagePart => WrappedElement.GetPart<T>(selector);
    
    protected List<T> GetParts<T>(string selector) where T : IPagePart => WrappedElement.GetParts<T>(selector);
}