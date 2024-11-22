namespace Mappify
{
    public partial class Mappify
    {
        public virtual TD Map<TS1, TD>(TS1 source)
        {
            if (source == null)
            {
                return default;
            }

            var sourceType = typeof(TS1);
            var destinationType = typeof(TD);

            var mappingFunction = InternalMap(sourceType, null, null, null, null, destinationType);

            return ((Func<TS1, TD>)mappingFunction)(source);
        }

        public virtual TD Map<TS1, TS2, TD>(TS1 source1, TS2 source2)
        {
            if (source1 == null)
            {
                return default;
            }

            var sourceType1 = typeof(TS1);
            var sourceType2 = typeof(TS2);
            var destinationType = typeof(TD);

            var mappingFunction = InternalMap(sourceType1, sourceType2, null, null, null, destinationType);

            return ((Func<TS1, TS2, TD>)mappingFunction)(source1, source2);
        }

        public virtual TD Map<TS1, TS2, TS3, TD>(TS1 source1, TS2 source2, TS3 source3)
        {
            if (source1 == null)
            {
                return default;
            }

            var sourceType1 = typeof(TS1);
            var sourceType2 = typeof(TS2);
            var sourceType3 = typeof(TS3);
            var destinationType = typeof(TD);

            var mappingFunction = InternalMap(sourceType1, sourceType2, sourceType3, null, null, destinationType);

            return ((Func<TS1, TS2, TS3, TD>)mappingFunction)(source1, source2, source3);
        }

        public virtual TD Map<TS1, TS2, TS3, TS4, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4)
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

            var mappingFunction = InternalMap(sourceType1, sourceType2, sourceType3, sourceType4, null, destinationType);

            return ((Func<TS1, TS2, TS3, TS4, TD>)mappingFunction)(source1, source2, source3, source4);
        }

        public virtual TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
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

            var mappingFunction = InternalMap(sourceType1, sourceType2, sourceType3, sourceType4, sourceType5, destinationType);

            return ((Func<TS1, TS2, TS3, TS4, TS5, TD>)mappingFunction)(source1, source2, source3, source4, source5);
        }

        protected virtual object InternalMap(
            Type sourceType1,
            Type sourceType2 = null,
            Type? sourceType3 = null,
            Type? sourceType4 = null,
            Type? sourceType5 = null,
            Type? destinationType = null)
        {
            if (_mappingConfigurations.TryGetValue((sourceType1, sourceType2, sourceType3, sourceType4, sourceType5, destinationType),
                    out var mappingFunction))
            {
                var func = mappingFunction;

                if (func == null)
                {
                    throw new MappifyException(
                        $"Mapping function for {sourceType1.Name}, {sourceType2?.Name}, {sourceType3?.Name}, {sourceType4?.Name}, {sourceType5?.Name} to {destinationType.Name} is not valid.");
                }

                return func;
            }

            throw new MappifyException($"Mapping profile required: {sourceType1.Name}, {sourceType2?.Name}, {sourceType3?.Name}, {sourceType4?.Name}, {sourceType5?.Name} to {destinationType.Name}");
        }
    }
}