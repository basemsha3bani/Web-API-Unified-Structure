using System;

namespace LinkedInWebAPI.LinkedInWebAPIClasses
{
    public abstract class APIFactory
    {

      

        public abstract IServiceProvider CreateServices();

        public ServiceCollection AddCommonServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            services.AddSingleton<IConfiguration>(configuration);
            return services;
        }

    }
    public class NumberOfFollwersAPIFactory : APIFactory
    {
        public override IServiceProvider CreateServices()
        {
           
            ServiceCollection services = new ServiceCollection();
        
            services.AddScoped<NumberOfFollwersAPIClass>();
            services = base.AddCommonServices(services);

            return services.BuildServiceProvider();
        }
    }

    public class LoginAPIFactory : APIFactory
    {
        public override IServiceProvider CreateServices()
        {

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<GetUserIdWebAPICaller>();
            services = base.AddCommonServices(services);

            return services.BuildServiceProvider();
        }
    }
    public enum APITypeEnum
    {
        LoginAPIF=1,
        NumberOfFollwersAPI=2

    }
}
