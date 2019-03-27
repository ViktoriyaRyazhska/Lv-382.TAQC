using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages
{
    public class SearchCriteriaPage : ASearchResultPart
    {
        //protected IWebDriver driver;

        public IWebElement SearchItemsCount
        { get { return driver.FindElement(MSearchCriteriaPage.locatorSearchItemsCount); } }
        public IWebElement ItemNotMatchesMessage
        { get { return driver.FindElement(MSearchCriteriaPage.locatorItemNotMatchesMessage); } }
        public IWebElement SearchAlertMessage
        { get { return driver.FindElement(MSearchCriteriaPage.locatorSearchAlertMessage); } }
        public IWebElement GridView
        { get { return driver.FindElement(MSearchCriteriaPage.locatorGridView); } }
        public IWebElement ListView
        { get { return driver.FindElement(MSearchCriteriaPage.locatorListView); } }

        public SearchCriteriaPage(IWebDriver driver) : base(driver)
        {
        }

        // Page Object
        
        //SearchItemsCount
        public string GetSearchItemsCount()
        {
            return SearchItemsCount.Text;
        }
        //SearchItemNotMatchesMessage
        public string GetItemNotMatchesMessage()
        {
            return ItemNotMatchesMessage.Text;
        }
        //SearchItemNotMatchesMessage
        public string GetSearchAlertMessage()
        {
            return SearchAlertMessage.Text;
        }
        //SearchGridViewButton
        public void ClickGridView()
        {
            GridView.Click();
        }
        //SearchListViewButton
        public void ClickListView()
        {
            ListView.Click();
        }

        // Functional
        public int FindActualCount()
        {
            return int.Parse(GetSearchItemsCount().Split(' ')[5]);
        }


        //public bool hasClass(IWebElement element, string searchedClass)
        //{
        //    string[] classes = element.GetAttribute("class").Split(' ');
        //    foreach (string str in classes)
        //    {
        //        if (str.Equals(searchedClass))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //Business Logic

    }
}
