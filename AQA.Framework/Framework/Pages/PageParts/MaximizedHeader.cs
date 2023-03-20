using AQA.Blank.Framework.Pages.Interfaces;
using OpenQA.Selenium;

namespace AQA.Blank.Framework.Pages.PageParts;

public class MaximizedHeader : BasePagePart<MaximizedHeader>, IHeader
{
    public ILinksSection LinksSection => GetPart<ILinksSection>(".xpathOrCss");

    public MaximizedHeader(Func<IWebElement> findFunc) : base(findFunc)
    {
    }
    
    protected override bool EvaluateLoadedStatus() => LinksSection.IsDisplayed;
}