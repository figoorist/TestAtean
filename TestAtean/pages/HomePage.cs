using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAtean.pages
{
    internal class HomePage : BasePage
    {
        public override IWebElement CoreElement
        { 
            get
            {
                return WebDriver.FindElement(By.XPath("//a[text()='Humans in Space']"));
            }
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
            WebDriver = driver;
        }

        public IWebElement GetMenuPoint(String menuName)
        {
            return WebDriver.FindElement(By.XPath("//a[@class='dropdown-toggle' and .//span[text()='" + menuName + "']]"));
        }

        public IWebElement GetSubMenuPoint(String menuName)
        {
            return WebDriver.FindElement(By.XPath("//li[./a[text()='" + menuName + "']]"));
        }
    } 
}