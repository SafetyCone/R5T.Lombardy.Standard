using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.Lombardy.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IStringlyTypedPathOperator"/> service.
        /// </summary>
        public static IServiceCollection AddStringlyTypedPathOperator(this IServiceCollection services)
        {
            services.AddDefaultStringlyTypedPathOperator();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IStringlyTypedPathOperator"/> service.
        /// </summary>
        public static ServiceAction<IStringlyTypedPathOperator> AddStringlyTypedPathOperatorAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IStringlyTypedPathOperator>(() => services.AddStringlyTypedPathOperator());
            return serviceAction;
        }
    }
}
