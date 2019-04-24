using RestTestProject.Data;
using RestTestProject.Data.RequestData;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Resources.AuthorizationResources;
using RestTestProject.Rules;

namespace RestTestProject.Services
{
    public interface IAdminService
    {
        Lifetime GetCurrentTokenLifetime();
        CoolDowntime GetCurrentCoolDowntime();
        bool CreateUser(IUser newUser);
        bool DeleteUser(IUser userToDelete);
        bool ChangePassword(string newUserPassword);
        bool LockUser(IUser userToLock);
        bool UnlockUser(IUser lockedUser);
        bool UpdateTokenlifetime(Lifetime lifetime);
        bool UpdateCoolDowntime(CoolDowntime cooldowntime);
        SimpleEntity GetUserName();
        string GetLoginedAdmins();
        string GetLoginedUsers();
        string GetAliveTockens();
        ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem);
        string GetUserItems(IUser userWithItem);
        string GetAllItems();
        string GetAllItemsIndexes();
        ItemTemplate GetItem(ItemTemplate itemTemplate);
        bool AddItem(ItemTemplate itemTemplate);
        bool UpdateItem(ItemTemplate itemTemplate);
        bool DeleteItem(ItemTemplate itemTemplate);
        bool IsLoggined();
        GuestService Logout();
    }

    public class AdminService : UserService, IAdminService
    {
        LoginedAdminsResourse loginedAdminsResourse;
        LockedUserResource lockedUserResource;
        AliveTockensResource aliveTockensResource;
        GetUserItemResource getUserItemResource;
        GetUserItemsResource getUserItemsResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            loginedAdminsResourse = new LoginedAdminsResourse();
            lockedUserResource = new LockedUserResource();
            aliveTockensResource = new AliveTockensResource();
            getUserItemResource = new GetUserItemResource();
            getUserItemsResource = new GetUserItemsResource();
        }
    
        public bool CreateUser(IUser newUser)
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
               .AddParameters(RequestParametersKeys.name.ToString(), newUser.Name)
               .AddParameters(RequestParametersKeys.password.ToString(), newUser.Password)
               .AddParameters(RequestParametersKeys.rights.ToString(), newUser.Rights);
            return userResorce.HttpPostAsObject(null, null, bodyParameters)
                .content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool DeleteUser(IUser userToDelete)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.name.ToString(), userToDelete.Name);
            return userResorce.HttpDeleteAsObject(null, null, bodyParameters)
                .content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool LockUser(IUser userToLock)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.name.ToString(), userToLock.Name);
            return lockedUserResource.HttpPostAsObject(null, pathParameters, bodyParameters)
                .content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UnlockUser(IUser lockedUser)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.name.ToString(), lockedUser.Name);
            return lockedUserResource.HttpPutAsObject(null, pathParameters, bodyParameters)
                .content.ToLower().Equals(true.ToString().ToLower());
        }

       

        public bool UpdateTokenlifetime(Lifetime lifetime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.time.ToString(), lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateCoolDowntime(CoolDowntime cooldowntime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.time.ToString(), cooldowntime.Time);
            SimpleEntity simpleEntity = coolDownTimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public string GetLoginedAdmins()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = loginedAdminsResourse.HttpGetAsObject(urlParameters, null);
            return simpleEntity.content;
        }

        public string GetLoginedUsers()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = adminAuthorizedResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity.content;
        }

        public string GetAliveTockens()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = aliveTockensResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity.content;
        }

        //--------------Item functionality----------------------------

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index)
                .AddParameters(RequestParametersKeys.name.ToString(), userWithItem.Name);
            SimpleEntity simpleEntity = getUserItemResource.HttpGetAsObject(urlParameters, pathParameters);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        public string GetUserItems(IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.name.ToString(), userWithItem.Name);
            SimpleEntity simpleEntity = getUserItemsResource.HttpGetAsObject(urlParameters, pathParameters);
            return simpleEntity.content;
        }
    }
}
