using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData.SimpleSearchData;
using OpenCart_Testing.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{

    [TestFixture]
    public class ChangeViewNumberOfElementsTest : TestRunner
    {
        private static readonly object[] SearchData_Case_DefaultView =
           ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json"));

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchChangeViewNumberOfElements_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);

            int beforeChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
            if (searchCriteriaPage.isView(ViewType.Grid))
            {
                searchCriteriaPage.ClickListView();
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }
            int afterChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
            Assert.AreEqual(beforeChange, afterChange);
        }
    }
}
