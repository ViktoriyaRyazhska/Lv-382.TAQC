using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpenCart.Service
{
    public class UserService : GuestService, IUserService
    {
        private string name;
        private string item;

        public UserService(string name) : base()
        {
            // Check
            if (!GuestService.isLoginRunning)
            {
                throw new Exception("***Error");
            }
            GuestService.isLoginRunning = false;
            this.name = name;
        }

        public string GetName()
        {
            Console.WriteLine("GetName() name = " + name);
            return name;
        }

        public bool AddItem(string item)
        {
            Console.WriteLine("AddItem() item = " + item);
            this.item = item;
            return true;
        }

        public string GetItem()
        {
            Console.WriteLine("GetItem() item = " + item);
            return item;
        }

        public GuestService Logout()
        {
            name = "";
            Console.WriteLine("Logout() name = " + name);
            return new GuestService();
        }
    }
}
