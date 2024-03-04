namespace LegacyApp.Services;

public class UserService:IUserService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUserCreditServiceHttpClient _userCreditServiceHttpClient;
    public UserService(IClientRepository clientRepository, IUserCreditServiceHttpClient userCreditServiceHttpClient) { 
        _clientRepository = clientRepository;
        _userCreditServiceHttpClient = userCreditServiceHttpClient;
    }
    public async Task<User> AddUser(string firstName, string surname, string email, DateTime dateOfBirth, int clientId)
    {

        var client = await _clientRepository.GetByIdAsync(clientId);

        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            Firstname = firstName,
            Surname = surname
        };

        if (client.Name == "VeryImportantClient")
        {
            // Skip credit check
            user.HasCreditLimit = false;
        }
        else if (client.Name == "ImportantClient")
        {
            // Do credit check and double credit limit
            user.HasCreditLimit = true;
            //using (var userCreditService = new UserCreditServiceClient())
            //{
            //    var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
            //    creditLimit = creditLimit * 2;
            //    user.CreditLimit = creditLimit;
            //}
            int creditLimit = _userCreditServiceHttpClient.GetCreditLimitAsync(user.Firstname, user.Surname, user.DateOfBirth).Result;
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;

        }
        else
        {
            // Do credit check
            user.HasCreditLimit = true;
            //using (var userCreditService = new UserCreditServiceClient())
            //{
            //    var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
            //    user.CreditLimit = creditLimit;
            //}
            int creditLimit = _userCreditServiceHttpClient.GetCreditLimitAsync(user.Firstname, user.Surname, user.DateOfBirth).Result;
            user.CreditLimit = creditLimit;
        }

        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            throw new InvalidOperationException("insufficient credit limit");
        }

        UserDataAccess.AddUser(user);

        return user;
    }
}
