using OpenQA.Selenium;

namespace AQA.Blank.Core.Utils;

public class Wait
{
    private const int DefaultTimeOutMs = 10000;
    private const int ShortTimeOutMs = 1500;
    private const int RetryIntervalMs = 50;

    public static void Until(Func<bool> condition, int timeOut = DefaultTimeOutMs)
    {
        var startTime = DateTime.Now;
        while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeOut)
        {
            try
            {
                if (condition())
                {
                    return;
                }
            }
            catch (Exception)
            {
                // skip
            }

            Thread.Sleep(RetryIntervalMs);
        }
    }

    public static void While(Func<bool> condition, double timeOut = DefaultTimeOutMs)
    {
        var startTime = DateTime.Now;
        while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeOut)
        {
            try
            {
                if (!condition())
                {
                    return;
                }
            }
            catch (Exception)
            {
                // skip
            }

            Thread.Sleep(RetryIntervalMs);
        }
    }

    public static void ABit(int timeout = ShortTimeOutMs)
    {
        Thread.Sleep(timeout);
    }

    public static void WhileElementMoving(ILocatable element)
    {
        var currentLocation = element.Coordinates.LocationInViewport;
        while (element.Coordinates.LocationInViewport != currentLocation)
        {
            currentLocation = element.Coordinates.LocationInViewport;
            ABit();
        }
    }
}