using Mappify;
using Mappify.Tests._0_Models;

namespace Mappify.Tests._1_MappingProfiles
{
    public class OverloadsMappingProfile : BaseMappingProfile
    {
        public override void CreateMaps(IMappify Mappify)
        {

            Mappify.CreateMap<SourceClass1, SourceClass2, DestinationClass>((source1, source2, Mappify) =>
            {
                var dest = new DestinationClass
                {
                    FromSource1 = Mappify.Map<DestinationClass>(source1),
                    FromSource2 = new DestinationClass() { Id = source2.Id, Name = source2.Name },
                };

                return dest;
            });

            Mappify.CreateMap<SourceClass1, SourceClass2, DestinationClass>((source1, source2, Mappify) =>
            {
                var dest = new DestinationClass
                {
                    FromSource1 = Mappify.Map<DestinationClass>(source1),
                    FromSource2 = new DestinationClass() { Id = source2.Id, Name = source2.Name },
                };

                return dest;
            });

            Mappify.CreateMap<SourceClass1, SourceClass2, SourceClass3, DestinationClass>((source1, source2, source3, Mappify) =>
            {
                var dest = new DestinationClass
                {
                    FromSource1 = Mappify.Map<DestinationClass>(source1),
                    FromSource2 = new DestinationClass() { Id = source2.Id, Name = source2.Name },
                    FromSource3 = new DestinationClass() { Id = source3.Id, Name = source3.Name },
                };

                return dest;
            });

            Mappify.CreateMap<SourceClass1, SourceClass2, SourceClass3, SourceClass4, DestinationClass>((source1, source2, source3, source4, Mappify) =>
            {
                var dest = new DestinationClass
                {
                    FromSource1 = Mappify.Map<DestinationClass>(source1),
                    FromSource2 = new DestinationClass() { Id = source2.Id, Name = source2.Name },
                    FromSource3 = new DestinationClass() { Id = source3.Id, Name = source3.Name },
                    FromSource4 = new DestinationClass() { Id = source4.Id, Name = source4.Name },
                };

                return dest;
            });

            Mappify.CreateMap<SourceClass1, SourceClass2, SourceClass3, SourceClass4, SourceClass5, DestinationClass>((source1, source2, source3, source4, source5, Mappify) =>
            {
                var dest = new DestinationClass
                {
                    FromSource1 = Mappify.Map<DestinationClass>(source1),
                    FromSource2 = new DestinationClass() { Id = source2.Id, Name = source2.Name},
                    FromSource3 = new DestinationClass() { Id = source3.Id, Name = source3.Name },
                    FromSource4 = new DestinationClass() { Id = source4.Id, Name = source4.Name },
                    FromSource5 = new DestinationClass() { Id = source5.Id, Name = source5.Name },
                };

                return dest;
            });
        }
    }
}