using Mappify;
using Mappify_Tests._1_MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Mappify_Tests.CollectionsTests
{
    public class CollectionsTests
    {
        IMappify _Mappify;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddMappify().AddMappifyProfile(typeof(ObjectMappingProfile));

            var serviceProvider = services.BuildServiceProvider();
            _Mappify = serviceProvider.GetRequiredService<IMappify>();
        }
    }
}