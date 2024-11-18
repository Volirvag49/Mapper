using Mappify.Tests._0_Models;
using Mappify.Tests._1_MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Mappify.Tests.ObjectsTests
{
    public class ObjectsTests
    {
        IMappify _mappify;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddMappify().AddMappifyProfile(typeof(ObjectMappingProfile));

            var serviceProvider = services.BuildServiceProvider();
            _mappify = serviceProvider.GetRequiredService<IMappify>();
        }

        [Test]
        public void Map_Object_Test()
        {
            var source1 = new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"};

            var dest1 = _mappify.Map<DestinationClass>(source1);

            Assert.NotNull(dest1);
            Assert.AreEqual(source1.Id, dest1.Id);
            Assert.AreEqual(source1.Name, dest1.Name);
        }

        [Test]
        public void Map_Array_From_Array_Test()
        {
            var source1 = new SourceClass1[]
            {
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-2"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-3"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-4"},
            };

            var dest1 = _mappify.Map<DestinationClass[]>(source1);

            Assert.NotNull(dest1);
            Assert.AreEqual(source1.Length, dest1.Length);
        }

        [Test]
        [Ignore("NotReady")]
        public void Map_Array_From_List_Test()
        {
            var source1 = new List<SourceClass1>
            {
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-2"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-3"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-4"},
            };

            var dest1 = _mappify.Map<DestinationClass[]>(source1);

            Assert.NotNull(dest1);
            Assert.AreEqual(source1.Count, dest1.Length);
        }

        [Test]
        public void Map_List_From_List()
        {
            var source1 = new List<SourceClass1>
            {
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-2"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-3"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-4"},
            };

            var dest1 = _mappify.Map<List<DestinationClass>>(source1);

            Assert.NotNull(dest1);
            Assert.AreEqual(source1.Count, dest1.Count);
        }

        [Test]
        [Ignore("NotReady")]
        public void Map_List_From_Array()
        {
            var source1 = new SourceClass1[]
            {
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-2"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-3"},
                new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-4"},
            };

            var dest1 = _mappify.Map<List<DestinationClass>>(source1);

            Assert.NotNull(dest1);
            Assert.AreEqual(source1.Length, dest1.Count);
        }
    }
}