using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace TestAtean.pages
{
    class EBooksPage : BasePage
    {
        public override IWebElement CoreElement
        {
            get
            {
                return WebDriver.FindElement(By.XPath("//div[@class='topic headline' and text()='E-Books']"));
            }
        }

        public EBooksPage(IWebDriver driver) : base(driver)
        {
            WebDriver = driver;
        }

        public IWebElement GetBookLinkByNumber(int bookNumber)
        {
            return WebDriver.FindElement(By.XPath("//div[@id='cards']/a[" + bookNumber.ToString() + "]"));
        }
    }
}
