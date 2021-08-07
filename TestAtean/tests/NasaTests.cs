using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAtean.steps;
using TestAtean.pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestAtean
{
    public class NasaTests
    {
        static ExtentReports extentReports;
        IWebDriver driver;

        NasaSteps nasaSteps;

        public void StartReport()
        {
            string
        }

        [SetUp]
        public void Setup()
        {
            extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Reports\");
            extentReports.AttachReporter(htmlReporter);

            driver = new ChromeDriver("drivers\\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            nasaSteps = new NasaSteps(
                new HomePage(driver),
                new EBooksPage(driver),
                new BookPage(driver)
                );
        }

        [Test]
        public void TestDownloadEBook()
        {
            var test = extentReports.CreateTest("Download E-Book test");
            test.Log(Status.Info, "Download E-Book test");
            test.Log(Status.Pass, "Successs!");

            driver.Navigate().GoToUrl("http://nasa.gov");
            nasaSteps.GoToEBookPage();
            nasaSteps.DownloadBook(1);

            extentReports.Flush();
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}