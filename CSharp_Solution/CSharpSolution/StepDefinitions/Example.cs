using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;

[Binding]
public class ExampleSteps
{
    private AndroidDriver<AndroidElement> driver;

    [BeforeScenario]
    public void Setup()
    {
        var appiumOptions = new AppiumOptions();
        appiumOptions.AddAdditionalCapability("platformName", "Android");
        appiumOptions.AddAdditionalCapability("deviceName", "Android Emulator");
        appiumOptions.AddAdditionalCapability("app", "path/to/your/app.apk"); // Path to your APK

        driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);
    }

    [Given(@"the app is opened")]
    public void GivenTheAppIsOpened()
    {
        // Open the app, driver setup is already done in Setup
    }

    [Then(@"the main screen should be visible")]
    public void ThenTheMainScreenShouldBeVisible()
    {
        var mainScreenElement = driver.FindElementByAccessibilityId("mainScreen"); // Use your main screen selector
        Assert.IsTrue(mainScreenElement.Displayed);
    }

    [AfterScenario]
    public void TearDown()
    {
        driver.Quit();
    }
}
