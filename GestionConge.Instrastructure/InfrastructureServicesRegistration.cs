using GestionConge.Application.Contracts.Email;
using GestionConge.Application.Contracts.Logging;
using GestionConge.Application.Models.Email;
using GestionConge.Instrastructure.EmailService;
using GestionConge.Instrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionConge.Instrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastrucuture(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            return services;
        }
    }
}