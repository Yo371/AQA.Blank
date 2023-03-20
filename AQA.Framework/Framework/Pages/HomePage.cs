using AQA.Blank.Framework.Pages.Interfaces;

namespace AQA.Blank.Framework.Pages;

public class HomePage : BasePage<HomePage>, IHomePage
{
    public const string Title = "Home";
    
    protected override bool EvaluateLoadedStatus() => Browser.Title.Equals(Title);
}