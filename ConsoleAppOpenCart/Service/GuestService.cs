using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpenCart.Service
{
    public class GuestService
    {
        public static bool isLoginRunning = false;

        public GuestService()
        {
        }

        //public UserService SuccessfulUserLogin(string name)
        public IUserService SuccessfulUserLogin(string name)
        {
            Console.WriteLine("SuccessfulUserLogin() name = " + name);
            isLoginRunning = true;
            return new UserService(name);
        }

    }
}
