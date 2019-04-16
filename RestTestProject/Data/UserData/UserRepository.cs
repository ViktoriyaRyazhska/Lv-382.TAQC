using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser ExistingAdmin()
        {
            return User.Get()
               .SetName("admin")
               .SetPassword("qwerty")
               .SetRigths(true.ToString())
               .Build();
        }

        public IUser ExistingUser()
        {
            return User.Get()
               .SetName("OKonokhtc")  //akimatc OKonokhtc
               .SetPassword("qwerty")
               .Build();
        }
 
        public IUser NonExistentUser()
        {
            return User.Get()
               .SetName("SomeUser")
               .SetPassword("qwerty")
               .Build();
        }
    }
}
