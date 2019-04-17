namespace RestTestProject.Data
{
    public interface IUser
    {
        string Name { get; }        // Required
        string Password { get; }    // Required
        string NewPassword { get; set; }
        string Rights { get; set; }
        string Token { get; set; }
    }
}
