using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GithubCmdlets.Models
{
    public class BasePage
    {

        protected IWebDriver webDriver;

        protected TimeSpan timeout = new TimeSpan(0, 0, 20);

        protected string _pageUrl;

        protected WebDriverWait wait;


        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

            var timeout = new TimeSpan(0, 0, 20);

            wait = new WebDriverWait(webDriver, timeout);            
        }

        public void GoTo()
        {
            webDriver.Navigate().GoToUrl(_pageUrl);
        }

        protected void SendKeys(By element, string keys)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            webDriver.FindElement(element).SendKeys(keys);
        }

        protected void Click(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            webDriver.FindElement(element).Click();
        }
    }
}
