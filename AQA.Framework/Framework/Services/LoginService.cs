using AQA.Blank.Core.Configuration.Models;
using AQA.Blank.Core.Factories;
using AQA.Blank.Core.Utils;
using AQA.Blank.Framework.Pages;
using AQA.Blank.Framework.Pages.Interfaces;

namespace AQA.Blank.Framework.Services;

public class LoginService
{
    private ILoginPage LoginPage => ObjectFactory.Get<ILoginPage>()!;
    
    private ICurrentPage CurrentPage => ObjectFactory.Get<ICurrentPage>()!;

    public void Login(User user)
    {
        CurrentPage.Header.LinksSection.SignInButton.Click();
        Reporter.Info($"Log in with user {GetPrimaryCredential(user)}");
        LoginPage.Login(GetPrimaryCredential(user), user.Password);
    }
    
    private string GetPrimaryCredential(User user)
    {
        return LoginPage.PrimaryCredentialName.Text.Contains("Membership Number")
            ? user.Name
            : user.Email;
    }
}