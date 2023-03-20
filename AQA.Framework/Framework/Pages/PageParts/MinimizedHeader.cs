using AQA.Blank.Framework.Pages.Interfaces;
using OpenQA.Selenium;

namespace AQA.Blank.Framework.Pages.PageParts;

public class MinimizedHeader : BasePagePart<MinimizedHeader>, IHeader
{
    public ILinksSection LinksSection => GetPart<ILinksSection>(".xpathOrCss");

    public MinimizedHeader(Func<IWebElement> findFunc) : base(findFunc)
    {
    }

    protected override bool EvaluateLoadedStatus() => LinksSection.IsDisplayed;
}