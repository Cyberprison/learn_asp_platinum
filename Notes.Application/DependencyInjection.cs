using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Reflection;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication
            (
            this IServiceCollection services
            )
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        
    }
}
