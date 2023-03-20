using System.Collections.ObjectModel;
using System.Drawing;
using AQA.Blank.Core;
using AQA.Blank.Core.Factories;
using AQA.Blank.Core.Utils;
using AQA.Blank.Framework.Pages.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions.Internal;

namespace AQA.Blank.Framework;

public class Element : IElement
{
    public IWebElement WrappedElement => _findFunc();

    private const int DefaultTimeOutMs = 10000;

    private readonly Func<IWebElement> _findFunc;

    private Browser Browser => BrowserFactory.GetBrowser();

    public Element(Func<IWebElement> findFunc)
    {
        _findFunc = findFunc;
    }

    public void WaitForPresence(int timeOut = DefaultTimeOutMs) => Wait.Until(() => WrappedElement.Displayed, timeOut);

    public void WaitWhilePresented(int timeOut = DefaultTimeOutMs) => Wait.While(() => IsDisplayed, timeOut);

    public void WaitWhileMoving() => Wait.WhileElementMoving(this);

    public void ScrollToElement() => Browser.ScrollToElement(WrappedElement);

    public void MoveToElement() => Browser.MoveToElement(WrappedElement);

    public Point LocationOnScreenOnceScrolledIntoView
        => ((ILocatable)WrappedElement).LocationOnScreenOnceScrolledIntoView;

    public ICoordinates Coordinates => ((ILocatable)WrappedElement).Coordinates;

    public IWebElement FindElement(By by) => WrappedElement.FindElement(by);

    public ReadOnlyCollection<IWebElement> FindElements(By by) => WrappedElement.FindElements(by);

    public void Clear()
    {
        WaitForPresence();
        WrappedElement.Clear();
    }

    public void SendKeys(string text)
    {
        WaitForPresence();
        WrappedElement.SendKeys(text);
    }

    public void Submit()
    {
        WaitForPresence();
        WrappedElement.Submit();
    }

    public void Click()
    {
        WaitForPresence();
        Wait.Until(() => WrappedElement.Enabled);
        WrappedElement.Click();
    }

    public string GetAttribute(string attributeName) => WrappedElement.GetAttribute(attributeName);

    public string GetCssValue(string propertyName) => WrappedElement.GetCssValue(propertyName);

    public string Text
    {
        get
        {
            WaitForPresence();
            return WrappedElement.Text;
        }
    }

    public Point Location => WrappedElement.Location;

    public bool IsDisplayed => WrappedElement.Displayed;

    public bool IsExist
    {
        get
        {
            try
            {
                _findFunc();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }

            return true;
        }
    }
}