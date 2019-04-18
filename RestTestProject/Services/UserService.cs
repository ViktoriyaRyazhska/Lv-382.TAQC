using RestTestProject.Data;
using RestTestProject.Data.RequestData;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;
using System;
using System.Collections.Generic;

namespace RestTestProject.Services
{
    public interface IUserService
    {
        Lifetime GetCurrentTokenLifetime();
        CoolDowntime GetCurrentCoolDowntime();
        SimpleEntity GetUserName();
        List<string> GetAllItems();
        List<string> GetAllItemsIndexes();
        ItemTemplate GetItem(ItemTemplate itemTemplate);
        bool AddItem(ItemTemplate itemTemplate);
        bool UpdateItem(ItemTemplate itemTemplate);
        bool DeleteItem(ItemTemplate itemTemplate);
        bool ChangePassword(string newUserPassword);
        bool IsLoggined();
        GuestService Logout();
    }

    public class UserService : GuestService, IUserService
    {
        //------------------ User ------------------------
        protected IUser user;
        protected UserResource userResorce;
        //------------------ Items ------------------------
        protected GetAllItemsIndexesResource getAllItemsIndexesResource;
        protected GetAllItemsResource getAllItemsResource;
        protected ManageItemResource manageItemResource;
        //-------------------------------------------------
        protected LogoutResource logoutResource;

        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            getAllItemsIndexesResource = new GetAllItemsIndexesResource();
            getAllItemsResource = new GetAllItemsResource();
            manageItemResource = new ManageItemResource();
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
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            return userResorce.HttpGetAsObject(urlParameters, null);
        }

        public bool ChangePassword(string newUserPassword)
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
               .AddParameters(RequestParametersKeys.oldpassword.ToString(), user.Password)
               .AddParameters(RequestParametersKeys.newpassword.ToString(), newUserPassword);
            return userResorce.HttpPutAsObject(null, null, bodyParameters)
                .content.ToLower().Equals(true.ToString().ToLower());
        }
        //------------------------------------------------------------

        //  <<<SERHII
        public List<string> GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = getAllItemsResource.HttpGetAsObject(urlParameters, null);
            return new List<string>(simpleEntity.content.Split('\n'));
        }

        public List<string> GetAllItemsIndexes()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = getAllItemsIndexesResource.HttpGetAsObject(urlParameters, null);
            return new List<string>(simpleEntity.content.Split('\n'));
        }

        public ItemTemplate GetItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            SimpleEntity simpleEntity = manageItemResource.HttpGetAsObject(urlParameters, pathParameters);
            Console.WriteLine("\t***GetItem()UserService: simpleEntity = " + simpleEntity);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        public bool AddItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.item.ToString(), itemTemplate.Item);
            SimpleEntity simpleEntity = manageItemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
            //Console.WriteLine("\t***AddItem()UserService: simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }
        //public bool AddItems(List<ItemTemplate> itemTemplateList)
        //{
        //    string successfulResponse = string.Empty;
        //    foreach (var current in itemTemplateList)
        //    {
        //        RestParameters pathParameters = new RestParameters()
        //        .AddParameters("index", current.Index);
        //        RestParameters bodyParameters = new RestParameters()
        //            .AddParameters("token", user.Token)
        //            .AddParameters("item", current.Item);
        //        SimpleEntity simpleEntity = manageItemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
        //        Console.WriteLine("\t***AddItem()UserService: simpleEntity = " + simpleEntity);
        //        successfulResponse = simpleEntity.content.ToLower();
        //    }
        //    return successfulResponse.Equals(true.ToString().ToLower());
        //}

        public bool UpdateItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.item.ToString(), itemTemplate.Item);
            SimpleEntity simpleEntity = manageItemResource.HttpPutAsObject(null, pathParameters, bodyParameters);
            Console.WriteLine("\t***UpdItem()UserService: simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool DeleteItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            SimpleEntity simpleEntity = manageItemResource.HttpDeleteAsObject(urlParameters, pathParameters, null);
            Console.WriteLine("\t***DelItem()UserService: simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }
        //  SERHII>>>
        //Roman

        public GuestService Logout()
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.name.ToString(), user.Name);
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
