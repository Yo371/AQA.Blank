using AQA.Blank.Framework.Pages.PageParts;

namespace AQA.Blank.Framework.Pages.Interfaces;

public interface ILinksSection : IPagePart
{
    IElement SignInButton { get; }

    bool IsDisplayed { get; }
}