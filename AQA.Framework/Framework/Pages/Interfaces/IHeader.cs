using AQA.Blank.Framework.Pages.PageParts;

namespace AQA.Blank.Framework.Pages.Interfaces;

public interface IHeader : IPagePart
{
    ILinksSection LinksSection { get; }
}