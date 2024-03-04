namespace LegacyApp.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "User firstname is required")]
    public string Firstname { get; set; }
    [Required(ErrorMessage = "User surname is required")]
    public string Surname { get; set; }
    [AgeGreaterThan21(ErrorMessage = "User should be older than 21 years")]
    public DateTime DateOfBirth { get; set; }
    [EmailAddress(ErrorMessage = "User email is invalid")]
    public string EmailAddress { get; set; }

    public int ClientId { get; set; }
    public bool HasCreditLimit { get; set; }

    public int CreditLimit { get; set; }

    public Client Client { get; set; }
}
