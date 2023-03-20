using AQA.Blank.Core.Factories;
using AQA.Blank.Framework.Services;
using NUnit.Framework.Interfaces;

namespace AQA.Tests.Attributes;

public class SmokeAttribute : CategoryAttribute, ITestAction
{

    public void BeforeTest(ITest test)
    {
        ObjectFactory.Get<PageOpenService>().OpenHomePage();
    }

    public void AfterTest(ITest test)
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            TestContext.AddTestAttachment(BrowserFactory.GetBrowser().TakeScreenshot());
    }

    public ActionTargets Targets => ActionTargets.Test;
}