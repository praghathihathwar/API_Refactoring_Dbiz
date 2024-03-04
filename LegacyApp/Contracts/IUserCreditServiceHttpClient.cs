namespace LegacyApp.Contracts;
public interface IUserCreditServiceHttpClient
{
    public Task<int> GetCreditLimitAsync(string firstName, string surname, DateTime dateOfBirth);
}

