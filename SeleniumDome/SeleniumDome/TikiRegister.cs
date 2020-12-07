using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumDome
{
    class TikiRegister
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://tiki.vn/";
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        [Test]
        public void Register()
        {
            IWebElement Login = driver.FindElement(By.CssSelector("div:nth-child(3)>span"));
            Actions action = new Actions(driver);
            action.MoveToElement(Login).Perform();

            IWebElement Create = driver.FindElement(By.CssSelector(".dYkBsI:nth-child(2)"));
            Create.Click();

            Thread.Sleep(3000);
        }
    }
}
