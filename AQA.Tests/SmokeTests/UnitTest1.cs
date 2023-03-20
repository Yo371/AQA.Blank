using AQA.Blank.Core.Configuration;
using AQA.Tests.Attributes;

namespace AQA.Tests.SmokeTests;

public class Tests : BaseTest
{
    [Test, Smoke]
    public void Test1()
    {
        LoginService.Login(ConfigurationManager.RunSettings.User);
        
        Assert.True(true);
    }
}