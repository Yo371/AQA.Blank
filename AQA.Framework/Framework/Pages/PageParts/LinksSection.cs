using AQA.Blank.Framework.Pages.Interfaces;
using OpenQA.Selenium;

namespace AQA.Blank.Framework.Pages.PageParts;

public class LinksSection : BasePagePart<LinksSection>, ILinksSection
{
    public IElement SignInButton => GetElement(".xpathOrCss");

    public LinksSection(Func<IWebElement> findFunc) : base(findFunc)
    {
    }
    
    public bool IsDisplayed => SignInButton.IsDisplayed;

    protected override bool EvaluateLoadedStatus() => IsDisplayed;
}