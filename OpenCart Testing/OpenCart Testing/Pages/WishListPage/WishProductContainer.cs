using OpenQA.Selenium;
using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using System.Collections.Generic;
using System;
using OpenCart_Testing.TestData.WishListData;

namespace OpenCart_Testing.Pages.WishPage
{
    public class WishProductContainer 
    {
        private IWebElement withProdContainer;

        private IList<WishProduct> wishProducts;

        public WishProductContainer(IWebElement withProdContainer)
        {
            this.withProdContainer = withProdContainer;
            InitElements();
        }

        private void InitElements()
        {
            wishProducts = new List<WishProduct>();
            IList<IWebElement> temp = withProdContainer.FindElements(MWishListPage.locatorWishItem);
            foreach (IWebElement current in temp)
            {
                wishProducts.Add(new WishProduct(current));
            }           
        }

        public IList<WishProduct> GetWishedItems()
        {
            return wishProducts;
        }

        public List<WishListItem> GetWishListItemsNames()
        {
            List<WishListItem> actualItems = new List<WishListItem>();

            if (GetWishedItemCount() == 0)
            {
                throw new Exception("List is empty.");
            }
            else
            {
                foreach (var item in GetWishedItems())
                {
                    actualItems.Add(new WishListItem(item.ProductNameText));
                    Console.WriteLine(item.ProductNameText+"\n");
                }
            }
            return actualItems;
        }

        public string GetEmptyListMessage()
        {
            if (GetWishedItemCount() > 0)
            {
                throw new Exception("List is not empty.");
            }
            else
            {
                return withProdContainer.FindElement(MWishListPage.locatorEmptyListMessage).Text;
            }           
        }

        public int GetWishedItemCount()
        {
            return GetWishedItems().Count;
        }

    }
}
