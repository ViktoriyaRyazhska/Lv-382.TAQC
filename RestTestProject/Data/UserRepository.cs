﻿using System;
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

        public IUser Admin()
        {
            return User.Get()
               .SetName("admin")
               .SetPassword("qwerty")
               .Build();
        }

        public IUser NewUser()
        {
            return User.Get()
               .SetName("akimatc")  //akimatc OKonokhtc
               .SetPassword("qwerty")
               .Build();
        }

        //Roman
        public IUser UnsuccessfulUser()
        {
            return User.Get()
               .SetName("ivan")
               .SetPassword("qwerty")
               .Build();
        }
    }
}
