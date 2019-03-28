using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    public static class MSearchCriteriaPage
    {
        public static By locatorSearchCriteriaField => By.Id("input-search");
        public static By locatorSearchCriteriaButton => By.Id("button-search");
        public static By locatorCategories => By.Name("category_id");
        public static By locatorSubcategories => By.Name("sub_category");
        public static By locatorProductDescription => By.Id("description");

        public static By locatorSearchItemsCount => By.CssSelector(".col-sm-6.text-right");
        public static By locatorSearchItemCaption => By.CssSelector(".caption a");
        public static By locatorItemNotMatchesMessage => By.CssSelector("#button-search ~ p");
        public static By locatorSearchAlertMessage => By.CssSelector("#button-search ~ p");
                                                       // By.Id("search_alert")                                                                  
        public static By locatorGridView => By.Id("grid-view");
        public static By locatorListView => By.Id("list-view");
    }
}
