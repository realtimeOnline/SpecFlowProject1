using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }


        [BeforeScenario(Order = 1)]
        public void BeforeScenarioStarts()
        {
            Console.WriteLine("Before Scenarion without tag");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);

        }
        [AfterScenario]
        public void AfterScenarioEnds()
        {
            Console.WriteLine("After Scenarion without tag");
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }

        }
        [BeforeScenario("@TestersTalk")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Before Scenarion using tag TestersTalk");
        }

        [AfterScenario("@TestersTalk")]
        public void AfterScenarioWithTag()
        {
            Console.WriteLine("After  Scenarion using tag TestersTalk");
        }

        

        [BeforeStep]
        public void BeforeStepStarts()
        {
            Console.WriteLine("Before Step");
        }

        [AfterStep]
        public void AfterStepEnds()
        {
            Console.WriteLine("After Step");
        }

        
    }
}
