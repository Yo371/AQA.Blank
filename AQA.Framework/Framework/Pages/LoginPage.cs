using AQA.Blank.Framework.Pages.Interfaces;

namespace AQA.Blank.Framework.Pages;

public class LoginPage : BasePage<LoginPage>, ILoginPage
{
    public string Title => "Login";

    public string Url => "/Authentication/Login";
    
    public IElement PrimaryCredentialName => GetElement("xpathOrCss");
    
    public IElement PrimaryCredentialInput => GetElement("#xpathOrCss");

    public IElement SecondaryCredentialInput => GetElement("#xpathOrCss");
    
    public IElement SignInButton => GetElement("xpathOrCss");

    public void Login(string primaryCredential, string secondaryCredential)
    {
        PrimaryCredentialInput.SendKeys(primaryCredential);
        SecondaryCredentialInput.SendKeys(secondaryCredential);
        SignInButton.Click();
    }

    protected override bool EvaluateLoadedStatus() => SignInButton.IsDisplayed;
}