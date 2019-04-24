namespace RestTestProject.Data
{
    public interface IUser
    {
        string Name { get; }       
        string Password { get; }    
        string NewPassword { get; set; }
        string Rights { get; set; }
        string Token { get; set; }
        IUser SwitchPasswords();
    }
}
