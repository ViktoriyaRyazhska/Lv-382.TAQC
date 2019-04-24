using RestTestProject.Data;
using RestTestProject.Data.RequestData;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;
using System;

namespace RestTestProject.Services
{
    public interface IUserService
    {
        Lifetime GetCurrentTokenLifetime();
        CoolDowntime GetCurrentCoolDowntime();
        SimpleEntity GetUserName();
        string GetAllItems();
        string GetAllItemsIndexes();
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

        //
        public string GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = getAllItemsResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity.content;
        }

        public string GetAllItemsIndexes()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = getAllItemsIndexesResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity.content;
        }

        public ItemTemplate GetItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            SimpleEntity simpleEntity = manageItemResource.HttpGetAsObject(urlParameters, pathParameters);
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
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.item.ToString(), itemTemplate.Item);
            SimpleEntity simpleEntity = manageItemResource.HttpPutAsObject(null, pathParameters, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool DeleteItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index);
            SimpleEntity simpleEntity = manageItemResource.HttpDeleteAsObject(urlParameters, pathParameters, null);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }
        //

        public GuestService Logout()
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.name.ToString(), user.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            if (simpleEntity.content.ToLower().Equals(true.ToString().ToLower()))
            {
                user.Token = string.Empty;
            }
            return new GuestService();
        }
    }
}
