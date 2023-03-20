using System.Reflection;
using OpenQA.Selenium;

namespace AQA.Blank.Core.Factories;

public class ObjectFactory
{
    public static T Get<T>(params object[] paramArray)
    {
        if (typeof(T).IsInterface)
        {
            var implementationType = Assembly.GetAssembly(typeof(T))?.GetTypes()
                .Single(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface);

            if (implementationType != null)
            {
                var instanceOfFoundImplementation = Activator.CreateInstance(implementationType, args: paramArray);
                return instanceOfFoundImplementation != null
                    ? (T)instanceOfFoundImplementation
                    : throw new NullReferenceException($"Instance of {typeof(T)} was not created");
            }

            throw new NullReferenceException($"Implementation of {typeof(T)} not found");
        }

        var instance = Activator.CreateInstance(typeof(T), args: paramArray);

        return instance != null
            ? (T)instance
            : throw new NullReferenceException($"Instance of {typeof(T)} was not created");
    }

    public static By GetBy(string selector)
    {
        var isXpath = selector.StartsWith("./") || selector.StartsWith("/") || selector.StartsWith("(./") || selector.StartsWith("(/");
        return isXpath ? By.XPath(selector) : By.CssSelector(selector);
    }
}