using System;
using System.Collections.Generic;
using System.Text;
using TestAtean.pages;
using OpenQA.Selenium;

namespace TestAtean.steps
{
    class NasaSteps
    {
        readonly HomePage homePage;
        readonly EBooksPage eBooksPage;
        readonly BookPage bookPage;

        public NasaSteps(HomePage homePage,
            EBooksPage eBooksPage,
            BookPage bookPage)
        {
            this.homePage = homePage;
            this.eBooksPage = eBooksPage;
            this.bookPage = bookPage;
        }

        public void GoToEBookPage()
        {
            homePage.GetMenuPoint("Downloads").Click();
            homePage.GetSubMenuPoint("E-Books").Click();
            eBooksPage.IsPresented();
        }

        public void DownloadBook(int bookNumberOnPage)
        {
            eBooksPage.GetBookLinkByNumber(bookNumberOnPage).Click();
            bookPage.IsPresented();
            bookPage.GetPDFLink().Click();
        }
    }
}
