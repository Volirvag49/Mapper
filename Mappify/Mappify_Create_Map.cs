namespace Mappify
{
    public partial class Mappify
    {
        public virtual void CreateMap<TS1, TD>(Func<TS1, TD> mappingFunction)
        {
            _mappingConfigurations[(typeof(TS1), default, default, default, default, typeof(TD))] = mappingFunction;
        }

        public virtual void CreateMap<TS1, TS2, TD>(Func<TS1, TS2, TD> mappingFunction)
        {
            _mappingConfigurations[(typeof(TS1), typeof(TS2), default, default, default, typeof(TD))] = mappingFunction;
        }

        public virtual void CreateMap<TS1, TS2, TS3, TD>(Func<TS1, TS2, TS3, TD> mappingFunction)
        {
            _mappingConfigurations[(typeof(TS1), typeof(TS2), typeof(TS3), default, default, typeof(TD))] = mappingFunction;
        }

        public virtual void CreateMap<TS1, TS2, TS3, TS4, TD>(Func<TS1, TS2, TS3, TS4, TD> mappingFunction)
        {
            _mappingConfigurations[(typeof(TS1), typeof(TS2), typeof(TS3), typeof(TS4), default, typeof(TD))] = mappingFunction;
        }

        public virtual void CreateMap<TS1, TS2, TS3, TS4, TS5, TD>(Func<TS1, TS2, TS3, TS4, TS5, TD> mappingFunction)
        {
            _mappingConfigurations[(typeof(TS1), typeof(TS2), typeof(TS3), typeof(TS4), typeof(TS5), typeof(TD))] = mappingFunction;
        }
    }
}