using OpenQA.Selenium;
using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using OpenCart_Testing.TestData.WishListData;
using System.Threading;

namespace OpenCart_Testing.Pages.WishListPage
{
    public class WishProductContainer
    {
        private IWebDriver driver;

        private IList<WishProduct> wishProducts;

        public WishProductContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }

        private void InitElements()
        {
            wishProducts = new List<WishProduct>();
            foreach (IWebElement current in driver.FindElements(MWishListPage.locatorWishItem))
            {
                wishProducts.Add(new WishProduct(current));
            }
        }

        public IList<WishProduct> GetWishedItems()
        {
            return wishProducts;
        }

        public bool CheckResultAddingToWishList(IList<WishListItem> productName)
        {
            List<WishProduct> actualItems = GetWishedItems().ToList<WishProduct>();
           
            if (GetWishedItemCount() == 0)
            {
                throw new Exception("List is empty.");
            }
            else
            {
                for (int i = 0; i < GetWishedItemCount(); i++)
                {
                    if (actualItems[i].ProductNameText != productName[i].Name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string GetEmptyListMessage()
        {
            if (GetWishedItemCount() > 0)
            {
                throw new Exception("List is not empty.");
            }
            else
            {
                return driver.FindElement(MWishListPage.locatorEmptyListMessage).Text;
            }           
        }

        public int GetWishedItemCount()
        {
            return GetWishedItems().Count;
        }

    }
}
