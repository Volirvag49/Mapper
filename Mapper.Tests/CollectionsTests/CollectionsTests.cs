using Mapper.Tests._1_MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Mapper.Tests.CollectionsTests
{
    public class CollectionsTests
    {
        IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddMapper().AddMapperProfile(typeof(ObjectMappingProfile));

            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}