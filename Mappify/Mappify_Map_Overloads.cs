namespace Mappify
{
    public partial class Mappify
    {
        public TD Map<TS1, TD>(TS1 source)
        {
            if (source == null)
            {
                return default;
            }

            var sourceType = typeof(TS1);
            var destinationType = typeof(TD);

            if (_mappingConfigurations.TryGetValue((sourceType, default, default, default, default, destinationType),
                    out var mappingFunction))
            {
                return ((Func<TS1, TD>)mappingFunction)(source);
            }


            throw new MappifyException($"Mapping profile required: {sourceType.Name} => {destinationType.Name}");
        }

        public TD Map<TS1, TS2, TD>(TS1 source1, TS2 source2)
        {
            if (source1 == null)
            {
                return default;
            }

            var sourceType1 = typeof(TS1);
            var sourceType2 = typeof(TS2);
            var destinationType = typeof(TD);

            if (_mappingConfigurations.TryGetValue((sourceType1, sourceType2, default, default, default, destinationType),
                    out var mappingFunction))
            {
                return ((Func<TS1, TS2, TD>)mappingFunction)(source1, source2);
            }

            throw new MappifyException(
                $"Mapping profile required: {sourceType1.Name}, {sourceType2.Name} => {destinationType.Name}");
        }

        public TD Map<TS1, TS2, TS3, TD>(TS1 source1, TS2 source2, TS3 source3)
        {
            if (source1 == null)
            {
                return default;
            }

            var sourceType1 = typeof(TS1);
            var sourceType2 = typeof(TS2);
            var sourceType3 = typeof(TS3);
            var destinationType = typeof(TD);

            if (_mappingConfigurations.TryGetValue((sourceType1, sourceType2, sourceType3, default, default, destinationType),
                    out var mappingFunction))
            {
                return ((Func<TS1, TS2, TS3, TD>)mappingFunction)(source1, source2, source3);
            }

            throw new MappifyException(
                $"Mapping profile required: {sourceType1.Name}, {sourceType2.Name}, {sourceType3.Name} => {destinationType.Name}");
        }

        public TD Map<TS1, TS2, TS3, TS4, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4)
        {
            if (source1 == null)
            {
                return default;
            }

            var sourceType1 = typeof(TS1);
            var sourceType2 = typeof(TS2);
            var sourceType3 = typeof(TS3);
            var sourceType4 = typeof(TS4);

            var destinationType = typeof(TD);

            if (_mappingConfigurations.TryGetValue((sourceType1, sourceType2, sourceType3, sourceType4, default, destinationType),
                    out var mappingFunction))
            {
                return ((Func<TS1, TS2, TS3, TS4, TD>)mappingFunction)(source1, source2, source3, source4);
            }

            throw new MappifyException(
                $"Mapping profile required: {sourceType1.Name}, {sourceType2.Name}, {sourceType3.Name} => {destinationType.Name}");
        }

        public TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
        {
            if (source1 == null)
            {
                return default;
            }

            var sourceType1 = typeof(TS1);
            var sourceType2 = typeof(TS2);
            var sourceType3 = typeof(TS3);
            var sourceType4 = typeof(TS4);
            var sourceType5 = typeof(TS5);

            var destinationType = typeof(TD);

            if (_mappingConfigurations.TryGetValue((sourceType1, sourceType2, sourceType3, sourceType4, sourceType5, destinationType),
                    out var mappingFunction))
            {
                return ((Func<TS1, TS2, TS3, TS4, TS5, TD>)mappingFunction)(source1, source2, source3, source4, source5);
            }

            throw new MappifyException(
                $"Mapping profile required: {sourceType1.Name}, {sourceType2.Name}, {sourceType3.Name} => {destinationType.Name}");
        }
    }
}