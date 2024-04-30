using Application.Features.Brands.Queries.GetListBrand;
using Application.Features.Brands.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Brands.Commands.CreateBrand.CreateBrandCommand;
using static Application.Features.Brands.Queries.GetListBrand.GetListBrandQuery;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           //services.AddMediatR(Assembly.GetExecutingAssembly());
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetListBrandQueryHandler).GetTypeInfo().Assembly));
           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBrandCommandHandler).GetTypeInfo().Assembly));


            services.AddScoped<BrandBusinessRules>();
           
          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            /*
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
              */
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
       
            return services;

        }
    }
}

