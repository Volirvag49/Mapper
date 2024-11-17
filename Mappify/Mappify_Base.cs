using Microsoft.Extensions.DependencyInjection;

namespace Mappify
{
    public partial class Mappify : IMappify
    {
        private readonly Dictionary<(Type, Type, Type?, Type?, Type?, Type?), Delegate> _mappingConfigurations = new();

        public Mappify(IServiceProvider provicer)
        {
            var profiles = provicer.GetServices<BaseMappingProfile>();

            foreach (var profile in profiles)
            {
                profile.CreateMaps(this);
            }
        }

        public Mappify(params BaseMappingProfile[] profiles)
        {
            foreach (var profile in profiles)
            {
                profile.CreateMaps(this);
            }
        }
    }
}