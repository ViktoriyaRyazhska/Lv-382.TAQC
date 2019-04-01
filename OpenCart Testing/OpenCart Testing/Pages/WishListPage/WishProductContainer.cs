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
            //wishProducts.Add(new WishProduct(driver.FindElement(By.XPath("//*[@id='content']/div[1]/table/tbody/tr[1]"))));
            //wishProducts.Add(new WishProduct(driver.FindElement(By.XPath("//*[@id='content']/div[1]/table/tbody/tr[2]"))));
            //wishProducts.Add(new WishProduct(driver.FindElement(By.XPath("//*[@id='content']/div[1]/table/tbody/tr[3]"))));
            //for (int i = 1; i < 4; i++)
            //{
            //    wishProducts[i-1].ProductName = driver.FindElement(By.XPath($"//*[@id='content']/div[1]/table/tbody/tr[{i}]/td[2]"));
            //}
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
