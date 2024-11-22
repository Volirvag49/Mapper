using System.Collections;

namespace Mappify
{
    public partial class Mappify
    {
        public virtual TD Map<TD>(object source)
        {
            if (source == null)
            {
                return default;
            }

            var sourceType = source.GetType();
            var destinationType = typeof(TD);

            if (sourceType.IsArray)
            {
                return InternalMapArray<TD>(source, sourceType, destinationType);
            }

            if (source is IList)
            {
                return InternalMapCollection<TD>(source, sourceType, destinationType);
            }

            if (IsGenericType(sourceType, typeof(Stack<>), out var stackGenericType))
            {
                throw new MappifyException(
                    $"Stack<> not supported. Use  MapStack<T>()");
            }

            if (IsGenericType(sourceType, typeof(Queue<>), out var queueGenericType))
            {
                throw new MappifyException(
                    $"Queue<> not supported. Use  MapQueue<T>()");
            }

            if (IsGenericType(sourceType, typeof(IDictionary<,>), out var dictionaryGenericTypes))
            {
                throw new MappifyException(
                    $"IDictionary not supported. Use  MapDictionary<T>()");
            }

            var result = InternalMapObject(source, sourceType, destinationType);

            return (TD)result;
        }

        protected virtual TD InternalMapCollection<TD>(object source, Type sourceType, Type destinationType)
        {
            if (source == null)
            {
                return default;
            }

            var destElementType = destinationType.IsGenericType
                ? destinationType.GetGenericArguments()[0]
                : destinationType;

            var resultCollection = (IList)Activator.CreateInstance(destinationType);

            foreach (var item in (IEnumerable)source)
            {
                var mapped = InternalMapObject(item, item.GetType(), destElementType);
                resultCollection.Add(mapped);
            }

            return (TD)resultCollection;
        }

        protected virtual TD InternalMapArray<TD>(object source, Type sourceType, Type destinationType)
        {
            if (source == null)
            {
                return default;
            }

            var destElementType = destinationType.GetElementType();

            var sourceArray = (Array)source;
            var resultArray = Array.CreateInstance(destElementType, sourceArray.Length);

            for (var i = 0; i < sourceArray.Length; i++)
            {
                var value = sourceArray.GetValue(i);
                var mapped = InternalMapObject(value, value.GetType(), destElementType);

                resultArray.SetValue(Convert.ChangeType(mapped, destElementType), i);
            }

            return (TD)(object)resultArray;
        }

        protected virtual object InternalMapObject(object source, Type sourceType, Type destinationType)
        {
            if (source == null)
            {
                return default;
            }

            if (_mappingConfigurations.TryGetValue((sourceType, default, default, default, default, destinationType),
                    out var mappingFunction))
            {
                var func = mappingFunction;

                if (func == null)
                {
                    throw new MappifyException(
                        $"Mapping function for {sourceType.Name} to {destinationType.Name} is not valid.");
                }

                return func.DynamicInvoke(source);
            }

            throw new MappifyException($"Mapping profile required: {sourceType.Name} => {destinationType.Name}");
        }

        protected virtual bool IsGenericType(Type type, Type genericTypeDefinition, out Type genericArgument)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition)
            {
                genericArgument = type.GetGenericArguments()[0];
                return true;
            }

            genericArgument = null;
            return false;
        }
    }
}