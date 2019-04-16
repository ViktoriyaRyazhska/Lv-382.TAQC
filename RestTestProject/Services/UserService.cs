using NUnit.Framework;
using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;
using System.Collections.Generic;

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

        //Roman
        public bool IsLoggout() 
        {
            return string.IsNullOrEmpty(user.Token);
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
        public List<SimpleEntity> GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            List<SimpleEntity> simpleEntity = getAllItemsResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public bool GetAllItemsIndexes()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = getAllItemsIndexesResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public ItemTemplate GetItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            SimpleEntity simpleEntity = manageItemResource.HttpGetAsObject(urlParameters, pathParameters);
            Console.WriteLine("\t***GetItem()UserService: simpleEntity = " + simpleEntity);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        public bool AddItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("item", itemTemplate.Item);
            SimpleEntity simpleEntity = manageItemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
            Console.WriteLine("\t***AddItem()UserService: simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
               .AddParameters("index", itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("item", itemTemplate.Item);
            SimpleEntity simpleEntity = manageItemResource.HttpPutAsObject(null, pathParameters, bodyParameters);
            Console.WriteLine("\t***UpdItem()UserService: simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool DeleteItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            SimpleEntity simpleEntity = manageItemResource.HttpDeleteAsObject(urlParameters, pathParameters, null);
            Console.WriteLine("\t***DelItem()UserService: simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
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
