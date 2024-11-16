using Microsoft.Extensions.DependencyInjection;

namespace Mapper
{
    public partial class Mapper : IMapper
    {
        private readonly Dictionary<(Type, Type, Type?, Type?, Type?, Type?), Delegate> _mappingConfigurations = new();

        public Mapper(IServiceProvider provicer)
        {
            var profiles = provicer.GetServices<BaseMappingProfile>();

            foreach (var profile in profiles)
            {
                profile.CreateMaps(this);
            }
        }

        public Mapper(params BaseMappingProfile[] profiles)
        {
            foreach (var profile in profiles)
            {
                profile.CreateMaps(this);
            }
        }
    }
}