using Microsoft.Extensions.DependencyInjection;

namespace Mappify
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Application DI.
        /// </summary>
        public static IServiceCollection AddMappify(this IServiceCollection services)
        {
            services.AddSingleton<IMappify, Mappify>();

            return services;
        }

        /// <summary>
        /// Application DI.
        /// </summary>
        public static IServiceCollection AddMappifyProfile(this IServiceCollection services, params Type[] profiles)
        {
            foreach (var profile in profiles)
            {
                services.AddSingleton(typeof(BaseMappingProfile), profile);
            }

            return services;
        }

        /// <summary>
        /// Application DI.
        /// </summary>
        public static IServiceCollection AddMappifyProfile<T>(this IServiceCollection services)
        {
            services.AddSingleton(typeof(BaseMappingProfile), typeof(T));

            return services;
        }
    }
}