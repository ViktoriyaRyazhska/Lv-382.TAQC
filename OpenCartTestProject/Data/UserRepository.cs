using OpenCartTestProject.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Data
{
    // 7. Singleton
    // 8. Repository
    public sealed class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)  //
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

        public IUser Registered()
        {
            return User.Get()
                .SetFirstname("Firstname8")
                .SetLastname("Lastname8")
                .SetEmail("Email8")
                .SetTelephone("123456")
                .SetAddress1("8Address1")
                .SetCity("City8")
                .SetPostcode("54321")
                .SetCountry("Country8")
                .SetRegionState("RegionState8")
                .SetPassword("Password8***")
                .SetSubscribe(true)
                .SetFax("Fax8***")
                .SetCompany("Company")
                .SetAddress2("Address2")
                .Build();
        }

        //public IUser NewUser() { }

        public IList<IUser> FromCsv()
        {
            return FromCsv("users.csv");
        }

        public IList<IUser> FromCsv(string filename)
        {
            return User.GetAllUsers(new CSVReader(filename).GetAllCells());
        }

        public IList<IUser> FromExcel()
        {
            return FromExcel("users.xlsx");
        }

        public IList<IUser> FromExcel(string filename)
        {
            return User.GetAllUsers(new ExcelReader(filename).GetAllCells());
        }

    }
}
