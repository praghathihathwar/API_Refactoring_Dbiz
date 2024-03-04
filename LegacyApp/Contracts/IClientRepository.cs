namespace LegacyApp.Contracts;
public interface IClientRepository
{
    public Task<Client> GetByIdAsync(int id);
}
