using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;

namespace RestTestProject.Services
{
    public class UserService : GuestService
    {
        //------------------ User ------------------------
        protected IUser user;
        protected UserResource userResorce;
        //------------------ Items ------------------------
        protected ALLItemsIndexesResource allItemsIndexesResource;
        protected ALLItemsResource allItemsResource;
        protected ItemResource itemResource;
        protected UserItemResource userItemResource;
        protected UserItemsResource userItemsResource;
        //-------------------------------------------------
        protected LogoutResource logoutResource;


        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            allItemsIndexesResource = new ALLItemsIndexesResource();
            allItemsResource = new ALLItemsResource();
            itemResource = new ItemResource();
            userItemResource = new UserItemResource();
            userItemsResource = new UserItemsResource();
            userResorce = new UserResource();
        }

        public bool IsLoggined()
        {
            return (user != null) && (!string.IsNullOrEmpty(user.Token));
        }

        //--------------User functionality----------------------------
        public SimpleEntity GetUserName()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            return userResorce.HttpGetAsObject(urlParameters, null);
        }

        public SimpleEntity ChangePassword()
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("oldpassword", user.Password)
               .AddParameters("newpassword", "SomeNewPassword");
            return userResorce.HttpPutAsObject(null, null, bodyParameters);
        }
        //------------------------------------------------------------

        //  <<<SERHII
        public SimpleEntity GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = allItemsResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetAllItemsIndexes()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = allItemsIndexesResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetItem()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = itemResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetUserItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
               //.AddParameters("name", user.Name);
            SimpleEntity simpleEntity = userItemsResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetUserItem()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = userItemResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity AddUserItem(string item)
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("item", item);
            SimpleEntity simpleEntity = userItemResource.HttpPostAsObject(urlParameters, null, null);
            return simpleEntity;
        }

        public SimpleEntity DeleteUserItem()
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = userItemResource.HttpDeleteAsObject(null, null, bodyParameters);
            return simpleEntity;
        }

        public SimpleEntity UpdateUserItem()
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("item", "bla");
            SimpleEntity simpleEntity = userItemResource.HttpPutAsObject(bodyParameters, null, null);
            return simpleEntity;
        }

        //  SERHII>>>


        public GuestService Logout()
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            //Checking for successful logout
            if (simpleEntity.content.ToLower().Equals(true.ToString().ToLower()))
            {
                //TODO exeption
                user.Token = string.Empty;
            }
            return new GuestService();
        }
        
    }
}
