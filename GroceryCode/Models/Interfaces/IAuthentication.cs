namespace GroceryCode.Models.Interfaces
{
    public interface IAuthentication : ISignUp, ILogin
    {
        string HashPassword(string password);

    }
}
