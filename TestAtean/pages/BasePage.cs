using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAtean.pages
{
    abstract class BasePage
    {
        protected IWebDriver WebDriver { get; set; }

        abstract public IWebElement CoreElement { get; }

        public bool IsPresented()
        {
            return CoreElement.Displayed;
        }

        public BasePage(IWebDriver driver)
        {
            WebDriver = driver;
        }
    }
}
