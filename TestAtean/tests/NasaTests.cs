using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAtean.steps;
using TestAtean.pages;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestAtean
{
    public class NasaTests
    {
        public ExtentReports extentReports;
        public ExtentTest test;

        IWebDriver driver;

        NasaSteps nasaSteps;

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\MyReport.html";

            extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@reportPath);
            extentReports.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("drivers\\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
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
            try
            {
                test = extentReports.CreateTest("Download E-Book test").Info("Test has started");

                driver.Navigate().GoToUrl("http://nasa.gov");
                test.Log(Status.Info, "Go to http://nasa.gov");
                nasaSteps.GoToEBookPage();
                test.Log(Status.Info, "Go to e-books page");
                nasaSteps.DownloadBook(1);
                test.Log(Status.Info, "Download any book");
                Assert.IsTrue(driver.Url.Contains(".pdf"));
                test.Log(Status.Pass, "Test passed!");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();

            
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extentReports.Flush();
        }
    }
}