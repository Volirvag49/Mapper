namespace Mapper
{
    public partial class Mapper
    {
        public List<TD> MapList<TD>(IEnumerable<object> sources)
        {
            if (sources == null)
            {
                return default;
            }

            var result = new List<TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TD>(source);

                if (mapped != null)
                {
                    result.Add(mapped);
                }
            }

            return result;
        }

        public List<TD> MapList<TD>(object[] sources)
        {
            if (sources == null)
            {
                return default;
            }

            var result = new List<TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TD>(source);

                if (mapped != null)
                {
                    result.Add(mapped);
                }
            }

            return result;
        }

        public TD[] MapArray<TD>(object[] sources)
        {
            if (sources == null)
            {
                return default;
            }

            //todo: Оптимизировать.
            var result = new List<TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TD>(source);

                if (mapped != null)
                {
                    result.Add(mapped);
                }
            }

            return result.ToArray();
        }

        public TD[] MapArray<TD>(IEnumerable<object> sources)
        {
            if (sources == null)
            {
                return default;
            }

            //todo: Оптимизировать.
            var result = new List<TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TD>(source);

                if (mapped != null)
                {
                    result.Add(mapped);
                }
            }

            return result.ToArray();
        }

        public Queue<TD> MapQueue<TS1, TD>(Queue<TS1> sources)
        {
            if (sources == null)
            {
                return default;
            }

            var result = new Queue<TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TS1, TD>(source);

                if (mapped != null)
                {
                    result.Enqueue(mapped);
                }
            }

            return result;
        }

        public Stack<TD> MapStack<TS1, TD>(Stack<TS1> sources)
        {
            if (sources == null)
            {
                return default;
            }

            var result = new Stack<TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TS1, TD>(source);

                if (mapped != null)
                {
                    result.Append(mapped);
                }
            }

            return result;
        }

        public IDictionary<TDk, TD> MapDictionary<TS1, TD, TDk>(IDictionary<TDk, TS1> sources)
        {
            if (sources == null)
            {
                return default;
            }

            var result = new Dictionary<TDk, TD>();

            foreach (var source in sources)
            {
                var mapped = Map<TS1, TD>(source.Value);

                if (mapped != null)
                {
                    result.Add(source.Key, mapped);
                }
            }

            return result;
        }
    }
}