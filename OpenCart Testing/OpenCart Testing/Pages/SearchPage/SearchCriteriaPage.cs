using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.TestData;

namespace OpenCart_Testing.Pages
{
    public enum ViewType
    {
        Grid = 1,
        List

    }

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

        public IWebElement SearchCriteriaField
        { get { return driver.FindElement(MSearchCriteriaPage.locatorSearchCriteriaField); } }
        public IWebElement SearchCriteriaButton
        { get { return driver.FindElement(MSearchCriteriaPage.locatorSearchCriteriaButton); } }
        public IWebElement Categories
        { get { return driver.FindElement(MSearchCriteriaPage.locatorCategories); } }
        public IWebElement Subcategories
        { get { return driver.FindElement(MSearchCriteriaPage.locatorSubcategories); } }
        public IWebElement ProductDescription
        { get { return driver.FindElement(MSearchCriteriaPage.locatorProductDescription); } }
        
        public SearchCriteriaPage(IWebDriver driver) : base(driver)
        {
        }

        // SearchCriteriaField
        public string GetSearchCriteriaFieldText()
        {
            return SearchCriteriaField.Text;
        }

        public void SetSearchCriteriaField(string text)
        {
            SearchCriteriaField.SendKeys(text);
        }

        public void ClearSearchCriteriaField()
        {
            SearchCriteriaField.Clear();
        }

        public void ClickSearchCriteriaField()
        {
            SearchCriteriaField.Click();
        }

        // SearchCriteriaButton
        public void ClickSearchCriteriaButton()
        {
            SearchCriteriaButton.Click();
        }

        // Categories
        public void ClickCategories()
        {
            Categories.Click();
        }

        //Subcategories
        public void ClickSubcategories()
        {
            Subcategories.Click();
        }

        //ProductDescription
        public void ClickProductDescription()
        {
            ProductDescription.Click();
        }

        public void SetCategories(string category)
        {
            new SelectElement(Categories).SelectByText(category);
        }

        public void ChooseProductDescription(bool click)
        {
            if (click == true)
                ClickProductDescription();
        }

        public void ChooseSearchInSubcategories(bool click)
        {
            if (click == true)
                ClickSubcategories();
        }

        // Functional
        protected void MakeSearchCriteria(string searchText, bool choiceDescription, string nameCategory, bool choiceSubcategories)
        {
            ClickSearchCriteriaField();
            ClearSearchCriteriaField();
            SetSearchCriteriaField(searchText);
            ChooseProductDescription(choiceDescription);
            SetCategories(nameCategory);
            ChooseSearchInSubcategories(choiceSubcategories);
            ClickSearchCriteriaButton();
        }

        // Business Logic
        public SearchCriteriaPage SearchCriteriaItems(string searchData, bool description, string category, bool subcategories)
        {
            MakeSearchCriteria(searchData, description, category, subcategories);          
            return new SearchCriteriaPage(driver);
        }

        public SearchCriteriaPage SearchCriteriaItems(ISearchCriteria searchCriteria)
        {
            MakeSearchCriteria(searchCriteria.Keyword, searchCriteria.Description, searchCriteria.Category, searchCriteria.Subcategory);
            return new SearchCriteriaPage(driver);
        }

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
        public bool isView(ViewType type)
        {
            switch (type)
            {
                case ViewType.Grid:
                    return GridView.GetAttribute("class").Contains("active");
                    break;
                case ViewType.List:
                    return ListView.GetAttribute("class").Contains("active");
                    break;
                default:
                    return false;
                    break;
            }
            //string[] classes = GridView.GetAttribute("class").Split(' ');
            //foreach (string str in classes)
            //{
            //    if (str.Equals("active"))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        //Business Logic

    }
}
