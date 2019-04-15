using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class SecondTest
    {
        [Test]
        public void ExamineAddItem()
        {
            IUser adminUser = UserRepository.Get().Admin();
            //
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            ItemTemplate existItem = ItemRepository.GetFirst();
            //
            adminService.AddItem(existItem);
            //
            ItemTemplate itemResult = adminService.GetUserItem(existItem, adminUser);
            Assert.AreEqual(existItem.Item, itemResult.Item);
        }

    }
}
