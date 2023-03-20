using AQA.Blank.Core.Utils;
using OpenQA.Selenium.Support.UI;

namespace AQA.Blank.Framework;

public abstract class Loadable<T> : LoadableComponent<T> where T : Loadable<T>
{
    protected override void ExecuteLoad() => Wait.Until(EvaluateLoadedStatus);
}