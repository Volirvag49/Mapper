using Mapper.Tests._0_Models;

namespace Mapper.Tests._1_MappingProfiles;

public class ObjectMappingProfile : BaseMappingProfile
{
    public override void CreateMaps(IMapper mapper)
    {
        mapper.CreateMap<SourceClass1, DestinationClass>((source1, mapper) => new DestinationClass
        {
            Id = source1.Id,
            Name = source1.Name,
        });
    }
}