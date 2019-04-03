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
    public class DefaultViewTest : TestRunner
    {
        private static readonly object[] SearchData_Case_DefaultView =
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json"));

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchDefaultView_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.IsTrue(searchCriteriaPage.isView(ViewType.Grid));
        }
    }
}
