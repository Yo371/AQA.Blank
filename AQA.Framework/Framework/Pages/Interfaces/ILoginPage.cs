namespace AQA.Blank.Framework.Pages.Interfaces;

public interface ILoginPage : IPage
{
    IElement PrimaryCredentialName { get; }

    IElement PrimaryCredentialInput { get; }

    IElement SecondaryCredentialInput { get; }

    IElement SignInButton { get; }

    void Login(string primaryCredential, string secondaryCredential);
}