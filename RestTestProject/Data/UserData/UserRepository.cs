using RestTestProject.Tools;

namespace RestTestProject.Data
{
    public sealed class UserRepository
    {
        public const string USER_NOT_FOUND_ERROR = "ERROR, user not found";
        public const string USER_LOCKED_ERROR = "ERROR, user locked";
        private const string directory = "UsersCredentials";
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository(){ }

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
        /*
        public IUser ExistingAdmin()
        {
            return User.Get().SetName("admin").SetPassword("qwerty").SetRigths(true.ToString()).Build();
        }

        public IUser ExistingUser()
        {
            return User.Get().SetName("akimatc").SetPassword("qwerty").SetNewPassword("SomeNewPassword").Build();
        }

        public IUser NonExistentUser()
        {
            return User.Get().SetName("SomeUser").SetPassword("qwerty").Build();
        }

        public IUser NonExistentAdmin()
        {
            return User.Get().SetName("SomeAdmin").SetPassword("qwerty").SetRigths(true.ToString()).Build();
        }*/

        public IUser ExistingAdmin()
        {
            return JsonParser.DeserializeFromFile<User>(directory, "ExistingAdminData.json");
        }

        public IUser ExistingUser()
        {
            return JsonParser.DeserializeFromFile<User>(directory, "ExistingUserData.json");
        }

        public IUser NonExistentAdmin()
        {
            return JsonParser.DeserializeFromFile<User>(directory, "NonExistentAdminData.json");
        }

        public IUser NonExistentUser()
        {
            return JsonParser.DeserializeFromFile<User>(directory, "NonExistentUserData.json");
        }

    }
}
