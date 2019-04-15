using RestSharp;
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
        protected GetAllItemsIndexesResource getAllItemsIndexesResource;
        protected GetAllItemsResource getAllItemsResource;
        protected GetUserItemResource getUserItemResource;
        protected ManageItemResource manageItemResource;
        protected GetUserItemsResource getUserItemsResource;
        //-------------------------------------------------
        protected LogoutResource logoutResource;


        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            getAllItemsIndexesResource = new GetAllItemsIndexesResource();
            getAllItemsResource = new GetAllItemsResource();
            getUserItemResource = new GetUserItemResource();
            manageItemResource = new ManageItemResource();
            getUserItemsResource = new GetUserItemsResource();
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

        public bool ChangePassword(string newUserPassword)
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("oldpassword", user.Password)
               .AddParameters("newpassword", newUserPassword);
            return userResorce.HttpPutAsObject(null, null, bodyParameters)
                .content.ToLower().Equals(true.ToString().ToLower());
        }
        //------------------------------------------------------------

        //  <<<SERHII
        public SimpleEntity GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = getAllItemsResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetAllItemsIndexes()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = getAllItemsIndexesResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetUserItem()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            //.AddParameters("name", user.Name);?????????????????????????????????????????
            //.AddParameters("index", user.Name);?????????????????????????????????????????
            SimpleEntity simpleEntity = getUserItemResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetUserItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            //.AddParameters("name", user.Name);????????????????? AS Admin ????????????????
            SimpleEntity simpleEntity = getUserItemsResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetItem()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            //.AddParameters("index", user.Name);
            SimpleEntity simpleEntity = manageItemResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity AddItem(string item)
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("item", item);
            //.AddParameters("index", user.Name);
            SimpleEntity simpleEntity = manageItemResource.HttpPostAsObject(urlParameters, null, null);
            return simpleEntity;
        }
        //public IRestRequest AddItem(string item) //, string index
        //{
        //    RestParameters urlParameters = new RestParameters()
        //       .AddParameters("token", user.Token)
        //    .AddParameters("item", item);
        //    SimpleEntity simpleEntity = manageItemResource.HttpPostAsObject(urlParameters, null, null);
        //    IRestRequest restRequest = new RestRequest(simpleEntity.ToString(), Method.POST)
        //        .AddUrlSegment("index", "222");
        //    return restRequest;
        //}

        public SimpleEntity UpdateItem(string item)
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("item", item);
            //.AddParameters("index", user.Name);
            SimpleEntity simpleEntity = manageItemResource.HttpPutAsObject(urlParameters, null, null);
            return simpleEntity;
        }
      
        public SimpleEntity UpdateUserItem()

        public SimpleEntity DeleteItem()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            //.AddParameters("index", user.Name);
            SimpleEntity simpleEntity = manageItemResource.HttpDeleteAsObject(urlParameters, null, null);
            return simpleEntity;
        }
        //  SERHII>>>
        //Roman


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
