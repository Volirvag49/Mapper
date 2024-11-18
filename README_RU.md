# Mappify

Mappify — это библиотека для простого и удобного маппинга объектов в C#. Она позволяет создавать маппинги между различными типами объектов с использованием функций, обеспечивая гибкость и простоту.

## Поддерживаемые типы маппинга

Mappify поддерживает следующие типы маппинга:

- Маппинг одиночных объектов
- Маппинг массивов
- Маппинг списков
- Маппинг очередей
- Маппинг стеков
- Маппинг словарей
- Маппинг из нескольких источников

## Установка

Вы можете установить библиотеку через NuGet:

```bash
dotnet add package Mappify
```

## Использование

### Настройка зависимостей

Для начала работы с библиотекой вам необходимо зарегистрировать `Mappify` и ваши профили маппинга в контейнере зависимостей. Это можно сделать следующим образом:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mappify;

var services = new ServiceCollection();
services.AddMappify();
services.AddMappifyProfile<MyMappingProfile>(); // Замените на ваш профиль маппинга
var serviceProvider = services.BuildServiceProvider();

var mappify = serviceProvider.GetRequiredService<IMappify>();
```

### Создание профиля маппинга

Создайте класс, унаследованный от `BaseMappingProfile`, и реализуйте метод `CreateMaps` для определения маппинга:

```csharp
public class MyMappingProfile : BaseMappingProfile
{
    public override void CreateMaps(IMappify mappify)
    {
        mappify.CreateMap<SourceClass, DestinationClass>(source => new DestinationClass
        {
            Property1 = source.Property1,
            Property2 = source.Property2
        });
    }
}
```

### Маппинг объектов

Теперь вы можете использовать созданный маппер для маппинга объектов:

```csharp
var source = new SourceClass { Property1 = "Value1", Property2 = "Value2" };
var destination = mappify.Map<SourceClass, DestinationClass>(source);
```

### Универсальный метод маппинга

Библиотека предоставляет универсальный метод для маппинга объектов:

```csharp
public TD Map<TD>(object source)
```

Этот метод позволяет маппить данные из объекта произвольного типа в целевой объект типа `TD`.
Пример использования:

```csharp
var source = new SourceClass { Property1 = "Value1", Property2 = "Value2" };
var destination = mappify.Map<DestinationClass>(source);
```
Он так же умеет работать с коллекциями и массивами.
Пример использования:

```csharp
var sourceList = new List<SourceClass>
{
    new SourceClass { Property1 = "Value1", Property2 = "Value2" },
    new SourceClass { Property1 = "Value3", Property2 = "Value4" }
};
var destinationList = mappify.Map<List<DestinationClass>>(sourceList);
```

### Маппинг коллекций

Библиотека также поддерживает маппинг коллекций. Вот несколько примеров:

#### Пример 1: Маппинг списка объектов

```csharp
var sourceList = new List<SourceClass>
{
    new SourceClass { Property1 = "Value1", Property2 = "Value2" },
    new SourceClass { Property1 = "Value3", Property2 = "Value4" }
};

var destinationList = mappify.MapList<DestinationClass>(sourceList);

// destinationList теперь содержит два объекта DestinationClass
```

#### Пример 2: Маппинг массива объектов

```csharp
var sourceArray = new SourceClass[]
{
    new SourceClass { Property1 = "Value1", Property2 = "Value2" },
    new SourceClass { Property1 = "Value3", Property2 = "Value4" }
};

var destinationArray = mappify.MapArray<DestinationClass>(sourceArray);

// destinationArray теперь содержит два объекта DestinationClass
```

#### Пример 3: Маппинг очереди объектов

```csharp
var sourceQueue = new Queue<SourceClass>();
sourceQueue.Enqueue(new SourceClass { Property1 = "Value1", Property2 = "Value2" });
sourceQueue.Enqueue(new SourceClass { Property1 = "Value3", Property2 = "Value4" });

var destinationQueue = mappify.MapQueue<SourceClass, DestinationClass>(sourceQueue);

// destinationQueue теперь содержит два объекта DestinationClass
```

#### Пример 4: Маппинг стека объектов

```csharp
var sourceStack = new Stack<SourceClass>();
sourceStack.Push(new SourceClass { Property1 = "Value1", Property2 = "Value2" });
sourceStack.Push(new SourceClass { Property1 = "Value3", Property2 = "Value4" });

var destinationStack = mappify.MapStack<SourceClass, DestinationClass>(sourceStack);

// destinationStack теперь содержит два объекта DestinationClass
```

#### Пример 5: Маппинг словаря объектов

```csharp
var sourceDictionary = new Dictionary<int, SourceClass>
{
    { 1, new SourceClass { Property1 = "Value1", Property2 = "Value2" } },
    { 2, new SourceClass { Property1 = "Value3", Property2 = "Value4" } }
};

var destinationDictionary = mappify.MapDictionary<SourceClass, DestinationClass, int>(sourceDictionary);

// destinationDictionary теперь содержит два объекта DestinationClass с теми же ключами
```

### Маппинг из нескольких источников

Существует несолько перегрузок для маппинга из нескольких источников в один объект.
```csharp
// Маппинг из 1 источника.
public TD Map<TS1, TD>(TS1 source1)

// Маппинг из 2 источников.
public TD Map<TS1, TS2, TD>(TS1 source1, TS2 source2, TS5 source5)

// Маппинг из 3 источников.
public TD Map<TS1, TS2, TS3, TD>(TS1 source1, TS2 source2, TS3 source3, TS5 source5)

// Маппинг из 4 источников.
public TD Map<TS1, TS2, TS3, TS4, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4)

// Маппинг из 5 источников.
public TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
```

#### Метод 1: Маппинг из одного источника

```csharp
public TD Map<TS1, TD>(TS1 source)
```

Этот метод позволяет маппить данные из одного источника `source` типа `TS1` в целевой объект типа `TD`. Он полезен, когда вам нужно преобразовать один объект в другой.

Пример использования:

```csharp
var singleSource = new SourceClass { Property1 = "Value1", Property2 = "Value2" };
var singleDestination = mappify.Map<SourceClass, DestinationClass>(singleSource);
```

#### Метод 2: Маппинг из нескольких источников

```csharp
public TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
```

Этот метод позволяет маппить данные из нескольких источников (до пяти) в целевой объект типа `TD`. Это удобно, когда вам нужно объединить данные из нескольких объектов в один.

Пример использования:

```csharp
var source1 = new SourceClass { Property1 = "Value1" };
var source2 = new OtherSourceClass { OtherProperty = "Value2" };
var source3 = new AdditionalSourceClass { AdditionalProperty = "Value3" };
var source4 = new FourthSourceClass { FourthProperty = "Value4" };
var source5 = new FifthSourceClass { FifthProperty = "Value5" };

// Создание маппинга из несольких источников
mappify.CreateMap<SourceClass, OtherSourceClass, AdditionalSourceClass, FourthSourceClass, FifthSourceClass, CombinedDestinationClass>(
        (source1, source2, source3, source4, source5) => 
        {
            var combinedDestination = new CombinedDestinationClass
            {
                CombinedProperty1 = source1.Property1,
                CombinedProperty2 = source2.OtherProperty,
                CombinedProperty3 = source3.AdditionalProperty,
                CombinedProperty4 = source4.FourthProperty,
                CombinedProperty5 = source5.FifthProperty
            };
            return combinedDestination;
        });


var combinedDestination = mappify.Map<SourceClass, OtherSourceClass, AdditionalSourceClass, FourthSourceClass, FifthSourceClass, CombinedDestinationClass>(source1, source2, source3, source4, source5);
```

## Исключения

В библиотеке определены исключения, которые могут возникать при ошибках маппинга:

- `MappifyException`: возникает, если маппинг для данного типа не определен.

## Вклад

Если вы хотите внести свой вклад в проект, пожалуйста, создайте форк репозитория, внесите изменения и создайте пулл-реквест.

## Лицензия

Этот проект лицензирован под MIT License - смотрите файл [LICENSE](LICENSE) для подробностей.

## Контакты

Если у вас есть вопросы или предложения, вы можете связаться со мной по почте lirikvolirvag@gmail.com
