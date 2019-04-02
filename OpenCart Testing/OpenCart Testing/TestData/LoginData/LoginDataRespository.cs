using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData.ChangePassData;
using OpenCart_Testing.Tools;

namespace OpenCart_Testing.TestData.LoginData
{
    class LoginDataRespository
    {
        private volatile static LoginDataRespository instance;
        private static object lockingObject = new object();
        private static string userDataDirectory = "UsersData";
                              
        public static LoginDataRespository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new LoginDataRespository();
                    }
                }
            }
            return instance;
        }

        public User GetUserLoginData(string fileName)
        {
            return JsonParser.DeserializeFromFile<User>(userDataDirectory, fileName);
        }

        public ChangePasswordData GetChangePasswordData(string fileName)
        {
            return JsonParser.DeserializeFromFile<ChangePasswordData>(userDataDirectory, fileName);
        }
    }
}
