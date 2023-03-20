using AQA.Blank.Core.Factories;
using AQA.Blank.Core.Utils;
using AQA.Blank.Framework.Pages.Interfaces;
using AQA.Blank.Framework.Pages.PageParts;
using OpenQA.Selenium;

namespace AQA.Blank.Framework;

public static class SearchContextExtension
{
    public static IElement GetElement(this ISearchContext searchContext, string selector)
    {
        var by = ObjectFactory.GetBy(selector);
        return ObjectFactory.Get<IElement>(() => searchContext.FindElement(by))!;
    }

    public static List<IElement> GetElements(this ISearchContext searchContext, string selector)
    {
        var by = ObjectFactory.GetBy(selector);
        Wait.Until(() => searchContext.FindElements(by).Count > 0);

        return new List<IElement>(searchContext.FindElements(by)
            .Select(e => ObjectFactory.Get<IElement>(() => e))
            .ToList());
    }

    public static T GetPart<T>(this ISearchContext searchContext, string selector) where T : IPagePart
    {
        var by = ObjectFactory.GetBy(selector);
        return ObjectFactory.Get<T>(() => searchContext.FindElement(by));
    }

    public static List<T> GetParts<T>(this ISearchContext searchContext, string selector) where T : IPagePart
    {
        var by = ObjectFactory.GetBy(selector);
        Wait.Until(() => searchContext.FindElements(by).Count > 0);

        return new List<T>(searchContext.FindElements(by)
            .Select(e => ObjectFactory.Get<T>(() => e))
            .ToList());
    }
}