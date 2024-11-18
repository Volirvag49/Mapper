namespace Mappify
{
    public interface IMappify
    {
        void CreateMap<TS1, TD>(Func<TS1,TD> mappingFunction);

        void CreateMap<TS1, TS2, TD>(Func<TS1, TS2, TD> mappingFunction);

        void CreateMap<TS1, TS2, TS3, TD>(Func<TS1, TS2, TS3, TD> mappingFunction);

        void CreateMap<TS1, TS2, TS3, TS4, TD>(Func<TS1, TS2, TS3, TS4, TD> mappingFunction);

        void CreateMap<TS1, TS2, TS3, TS4, TS5, TD>(Func<TS1, TS2, TS3, TS4, TS5, TD> mappingFunction);

        TD Map<TD>(object source);

        TD Map<TS1, TD>(TS1 source);

        TD Map<TS1, TS2, TD>(TS1 source1, TS2 source2);

        TD Map<TS1, TS2, TS3, TD>(TS1 source1, TS2 source2, TS3 source3);

        TD Map<TS1, TS2, TS3, TS4, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4);

        TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5);

        List<TD> MapList<TD>(IEnumerable<object> sources);

        List<TD> MapList<TD>(object[] sources);

        TD[] MapArray<TD>(object[] sources);

        TD[] MapArray<TD>(IEnumerable<object> sources);

        Queue<TD> MapQueue<TS1, TD>(Queue<TS1> sources);

        Stack<TD> MapStack<TS1, TD>(Stack<TS1> sources);

        IDictionary<TDk, TD> MapDictionary<TS1, TD, TDk>(IDictionary<TDk, TS1> sources);
    }
}