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

        /// <summary>
        /// Adds stringly-typed path-related operator services.
        /// </summary>
        public static IServiceCollection AddStringlyTypedPathRelatedOperators(this IServiceCollection services)
        {
            services
                .AddSingleton<IDirectoryNameOperator, DirectoryNameOperator>()
                .AddSingleton<IDirectorySeparatorOperator, IDirectorySeparatorOperator>()
                .AddSingleton<IFileExtensionOperator, FileExtensionOperator>()
                .AddSingleton<IFileNameOperator, FileNameOperator>()
                .AddStringlyTypedPathOperator()
                ;

            return services;
        }

        /// <summary>
        /// Adds stringly-typed path-related operator services.
        /// </summary>
        public static (
            IServiceAction<IDirectoryNameOperator> directoryNameOperatorAction,
            IServiceAction<IDirectorySeparatorOperator> directorySeparatorOperatorAction,
            IServiceAction<IFileExtensionOperator> fileExtensionOperatorAction,
            IServiceAction<IFileNameOperator> fileNameOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction
            ) AddStringlyTypedPathRelatedOperatorsAction(this IServiceCollection services)
        {
            var output = (
                directoryNameOperatorAction: ServiceAction<IDirectoryNameOperator>.New(() => services.AddSingleton<IDirectoryNameOperator, DirectoryNameOperator>()),
                directorySeparatorOperatorAction: ServiceAction<IDirectorySeparatorOperator>.New(() => services.AddSingleton<IDirectorySeparatorOperator, DirectorySeparatorOperator>()),
                fileExtensionOperatorAction: ServiceAction<IFileExtensionOperator>.New(() => services.AddSingleton<IFileExtensionOperator, FileExtensionOperator>()),
                fileNameOperatorAction: ServiceAction<IFileNameOperator>.New(() => services.AddSingleton<IFileNameOperator, FileNameOperator>()),
                stringlyTypedPathOperatorAction: ServiceAction<IStringlyTypedPathOperator>.New(() => services.AddStringlyTypedPathOperator())
                );

            return output;
        }
    }
}
