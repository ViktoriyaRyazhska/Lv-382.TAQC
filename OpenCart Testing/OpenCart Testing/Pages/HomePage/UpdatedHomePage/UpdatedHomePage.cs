using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenCart_Testing.Pages.UIMapping.MUpdatedHomePage;

namespace OpenCart_Testing.Pages
{
    public class UpdatedHomePage : HomePage
    {
        protected IWebElement updatedMessage=>driver.FindElement(MUpdatedHomePage.locatorMessageForNotLogged);
        protected IWebElement succesMessage => driver.FindElement(MUpdatedHomePage.locatorMessageSuccessAddingToWishList);
        public UpdatedHomePage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement GetUpdatedMessage()
        {
            return updatedMessage;
        }

        public IWebElement GetSuccessMessage()
        {
            return succesMessage;
        }
    }
}
