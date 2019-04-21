namespace RestTestProject.Data
{
    public sealed class UserRepository
    {
        public static string USER_NOT_FOUND_ERROR = "ERROR, user not found";
        public static string USER_ALREADY_EXIST_ERROR = "ERROR, user already exist";
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

        public IUser NonExistentAdminUser()
        {
            return User.Get().SetName("SomeAdmin").SetPassword("qwerty").SetRigths(true.ToString()).Build();
        }

    }
}
