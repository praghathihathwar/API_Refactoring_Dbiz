using LegacyApp.Contracts;
using LegacyApp.Repository;
using LegacyApp.Services;


namespace LegacyApp.Api.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserCreditServiceHttpClient, UserCreditServiceHttpClient>();
            services.AddScoped<HttpClient>();
            services.AddSingleton(configuration);
            services.AddScoped<IDatabaseConfig,DatabaseConfig>();

            services.AddLogging();


            return services;
        }
    }
}
