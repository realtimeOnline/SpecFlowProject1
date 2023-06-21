using OpenQA.Selenium;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class FeatureStepDefinitions
    {
        private IWebDriver driver;
        public FeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
           // driver = new ChromeDriver();
        }

        [When(@"Enter the URL")]
        public void WhenEnterTeURL()
        {
            driver.Url = "https://www.youtube.com/";
    
        }

        [Then(@"Search for the Testers Talk")]
        public void ThenSearchForTheTestersTalk()
        {
            driver.FindElement(By.XPath("//input[@id=\"search\"]")).SendKeys("Testers Talk");
            driver.FindElement(By.XPath("//input[@id=\"search\"]")).SendKeys(Keys.Enter);
            Thread.Sleep(4000);
            driver.Close();
          }

    }
}