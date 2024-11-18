using Mappify.Tests._0_Models;
using Mappify.Tests._1_MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Mappify.Tests.OverloadsTests
{
    public class OverloadsTests
    {
        IMappify _mappify;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddMappify();

            services.AddMappifyProfile(typeof(ObjectMappingProfile));
            services.AddMappifyProfile(typeof(OverloadsMappingProfile));

            var serviceProvider = services.BuildServiceProvider();
            _mappify = serviceProvider.GetRequiredService<IMappify>();
        }

        [Test]
        public void Map_Overloads_From_1_Sources_Test()
        {
            var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };

            var dest1 = _mappify.Map<SourceClass1, DestinationClass>(source1);

            AssertFields(source1, dest1);

        }

        [Test]
        public void Map_Overloads_From_2_Sources_Test()
        {
            var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
            var source2 = new SourceClass2() { Id = Guid.NewGuid(), Name = "Source-2" };

            var dest1 = _mappify.Map<SourceClass1, SourceClass2,
                DestinationClass>(source1, source2);

            AssertFields(source1, dest1.FromSource1);
            AssertFields(source2, dest1.FromSource2);
        }

        [Test]
        public void Map_Overloads_From_3_Sources_Test()
        {
            var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
            var source2 = new SourceClass2() { Id = Guid.NewGuid(), Name = "Source-2" };
            var source3 = new SourceClass3() { Id = Guid.NewGuid(), Name = "Source-3" };

            var dest1 = _mappify.Map<SourceClass1, SourceClass2, SourceClass3,
                DestinationClass>(source1, source2, source3);

            AssertFields(source1, dest1.FromSource1);
            AssertFields(source2, dest1.FromSource2);
            AssertFields(source3, dest1.FromSource3);
        }

        [Test]
        public void Map_Overloads_From_4_Sources_Test()
        {
            var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
            var source2 = new SourceClass2() { Id = Guid.NewGuid(), Name = "Source-2" };
            var source3 = new SourceClass3() { Id = Guid.NewGuid(), Name = "Source-3" };
            var source4 = new SourceClass4() { Id = Guid.NewGuid(), Name = "Source-4" };

            var dest1 = _mappify.Map<SourceClass1, SourceClass2, SourceClass3,
                SourceClass4, DestinationClass>(source1, source2, source3, source4);

            AssertFields(source1, dest1.FromSource1);
            AssertFields(source2, dest1.FromSource2);
            AssertFields(source3, dest1.FromSource3);
            AssertFields(source4, dest1.FromSource4);
        }

        [Test]
        public void Map_Overloads_From_5_Sources_Test()
        {
            var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
            var source2 = new SourceClass2() { Id = Guid.NewGuid(), Name = "Source-2" };
            var source3 = new SourceClass3() { Id = Guid.NewGuid(), Name = "Source-3" };
            var source4 = new SourceClass4() { Id = Guid.NewGuid(), Name = "Source-4" };
            var source5 = new SourceClass5() { Id = Guid.NewGuid(), Name = "Source-5" };

            var dest1 = _mappify.Map<SourceClass1, SourceClass2, SourceClass3,
                SourceClass4, SourceClass5, DestinationClass>(source1, source2, source3, source4, source5);

            AssertFields(source1, dest1.FromSource1);
            AssertFields(source2, dest1.FromSource2);
            AssertFields(source3, dest1.FromSource3);
            AssertFields(source4, dest1.FromSource4);
            AssertFields(source5, dest1.FromSource5);
        }

        private void AssertFields(SourceClass1 source, DestinationClass dest)
        {
            Assert.NotNull(dest);
            Assert.AreEqual(source.Id, dest.Id);
            Assert.AreEqual(source.Name, dest.Name);
        }
    }
}