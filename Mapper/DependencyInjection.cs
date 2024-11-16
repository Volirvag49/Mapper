using Microsoft.Extensions.DependencyInjection;

namespace Mapper
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Application DI.
        /// </summary>
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();

            return services;
        }

        /// <summary>
        /// Application DI.
        /// </summary>
        public static IServiceCollection AddMapperProfile(this IServiceCollection services, params Type[] profiles)
        {
            foreach (var profile in profiles)
            {
                services.AddSingleton(typeof(BaseMappingProfile), profile);
            }

            return services;
        }
    }
}