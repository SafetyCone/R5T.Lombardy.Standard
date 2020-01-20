using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.Lombardy.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddStringlyTypedPathOperator(this IServiceCollection services)
        {
            services.AddSingleton<IStringlyTypedPathOperator, StringlyTypedPathOperator>();

            return services;
        }
    }
}
