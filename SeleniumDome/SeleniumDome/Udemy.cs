using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumDome
{
    class Udemy
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://www.udemy.com/";
            Thread.Sleep(1000);
            IWebElement SignUp = driver.FindElement(By.CssSelector
            (".udlite-btn-medium.udlite-btn-primary:nth-child(1)"));
            SignUp.Click();

            Thread.Sleep(1000);

            IWebElement FullName = driver.FindElement(By.CssSelector("#id_fullname"));
            FullName.SendKeys("Nguyen Cao Thang");

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(1000);
            driver.Url = "https://www.crazymailing.com/vi/";

            String TempEmail = driver.FindElement(By.CssSelector("#email_addr")).Text;

            driver.SwitchTo().Window(driver.WindowHandles.First());

            IWebElement Email = driver.FindElement(By.CssSelector("#email--1"));
            Email.SendKeys(TempEmail);

            IWebElement Password = driver.FindElement(By.CssSelector("#password"));
            Password.SendKeys("Thang13201008*");

            String PasswordMessage = driver.FindElement(By.CssSelector
            (".password-form-group--strength-indicator__text--2PZb6")).Text;

            Assert.IsTrue(PasswordMessage.Contains("Very strong password"));

            IWebElement SubmitButton = driver.FindElement(By.CssSelector("#submit-id-submit"));
            SubmitButton.Submit();

            Thread.Sleep(2000);

            String title = driver.Title;

            Assert.IsTrue(title.Contains("Online Courses - Anytime, Anywhere | Udemy"));
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
