using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Application.Features.DepositRequests.Rules;
using Mailing;
using Application.Features.Auths.AuthRules;
using Application.Services.AuthService;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
          
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<AuthBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<DepositBusinessRules>();


            services.AddScoped<IAuthService, AuthService>();




            return services;
        }
    }
}
