namespace LegacyApp.Contracts;

public interface IUserService
{
    public Task<User> AddUser(string firstName, string surname, string email, DateTime dateOfBirth, int clientId);
}
