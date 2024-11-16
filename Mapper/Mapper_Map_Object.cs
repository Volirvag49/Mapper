﻿using System.Collections;

namespace Mapper
{
    public partial class Mapper
    {
        public TD Map<TD>(object source)
        {
            if (source == null)
            {
                return default;
            }

            var sourceType = source.GetType();
            var destinationType = typeof(TD);

            if (sourceType.IsArray)
            {
                return MapArray<TD>(source, sourceType, destinationType);
            }

            if (source is IList)
            {
                return MapCollection<TD>(source, sourceType, destinationType);
            }

            if (IsGenericType(sourceType, typeof(Stack<>), out var stackGenericType))
            {
                throw new MapperException(
                    $"Stack<> not supported. Use  MapStack<T>()");
            }

            if (IsGenericType(sourceType, typeof(Queue<>), out var queueGenericType))
            {
                throw new MapperException(
                    $"Queue<> not supported. Use  MapQueue<T>()");
            }

            if (IsGenericType(sourceType, typeof(IDictionary<,>), out var dictionaryGenericTypes))
            {
                throw new MapperException(
                    $"IDictionary not supported. Use  MapDictionary<T>()");
            }

            ////if (source is BitArray)
            ////{
            ////    
            ////}

            var result = MapObject(source, sourceType, destinationType);

            return (TD)result;
        }

        private TD MapCollection<TD>(object source, Type sourceType, Type destinationType)
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
                var mapped = MapObject(item, item.GetType(), destElementType);
                resultCollection.Add(mapped);
            }

            return (TD)resultCollection;
        }

        private TD MapArray<TD>(object source, Type sourceType, Type destinationType)
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
                var mapped = MapObject(value, value.GetType(), destElementType);

                resultArray.SetValue(Convert.ChangeType(mapped, destElementType), i);
            }

            return (TD)(object)resultArray; // Приведение к TD
        }

        private object MapObject(object source, Type sourceType, Type destinationType)
        {
            if (source == null)
            {
                return default;
            }

            // Проверка, существует ли маппинг для данного типа
            if (_mappingConfigurations.TryGetValue((sourceType, default, default, default, default, destinationType),
                    out var mappingFunction))
            {
                // Приведение к делегату, принимающему object
                var func = mappingFunction;

                if (func == null)
                {
                    throw new MapperException(
                        $"Mapping function for {sourceType.Name} to {destinationType.Name} is not valid.");
                }

                // Вызов делегата с использованием reflection
                return func.DynamicInvoke(source, this);
            }

            throw new MapperException($"Mapping profile required: {sourceType.Name} => {destinationType.Name}");
        }


        private bool IsGenericType(Type type, Type genericTypeDefinition, out Type genericArgument)
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