using LegacyApp.Contracts;
using Microsoft.Extensions.Configuration;


namespace LegacyApp.Repository
{
    public class DatabaseConfig :IDatabaseConfig
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("appDatabase");
        }
    }
}
