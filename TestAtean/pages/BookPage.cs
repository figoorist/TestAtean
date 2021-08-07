using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAtean.pages
{
    class BookPage : BasePage
    {
        public override IWebElement CoreElement
        {
            get
            {
                return WebDriver.FindElement(By.XPath("//div[@class='article-body']"));
            }
        }

        public BookPage(IWebDriver driver) : base(driver)
        {
            WebDriver = driver;
        }

        public IWebElement GetPDFLink()
        {
            return WebDriver.FindElement(By.XPath("//a[contains(@href, '.pdf')]"));
        }
    }
}
