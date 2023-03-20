namespace AQA.Blank.Framework.Pages;

public interface ICurrentPage : IPage
{
}

public class CurrentPage : BasePage<CurrentPage>, ICurrentPage
{
    protected override bool EvaluateLoadedStatus() => Header.LinksSection.IsDisplayed;
}