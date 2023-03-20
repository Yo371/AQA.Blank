using OpenQA.Selenium;

namespace AQA.Blank.Framework.Pages.Interfaces;

public interface IElement : ILocatable, IWrapsElement, ISearchContext
{
    void ScrollToElement();
    
    void MoveToElement();

    void WaitForPresence(int timeOut);

    void WaitWhilePresented(int timeOut);

    void WaitWhileMoving();

    void Clear();

    void SendKeys(string text);

    void Submit();

    void Click();

    string GetAttribute(string attributeName);

    string GetCssValue(string propertyName);

    string Text { get; }

    bool IsDisplayed { get; }

    bool IsExist { get; }
}