# Mappify

Mappify is a library for easy and convenient object mapping in C#. It allows you to create mappings between different types of objects using functions, providing flexibility and simplicity.

## Supported Mapping Types

Mappify supports the following types of mappings:

- Single object mapping
- Array mapping
- List mapping
- Queue mapping
- Stack mapping
- Dictionary mapping
- Mapping from multiple sources

## Installation

You can install the library via NuGet:

```bash
dotnet add package Mappify
```

## Usage

### Setting Up Dependencies

To start working with the library, you need to register `Mappify` and your mapping profiles in the dependency container. You can do this as follows:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mappify;

var services = new ServiceCollection();
services.AddMappify();
services.AddMappifyProfile<MyMappingProfile>(); // Replace with your mapping profile
var serviceProvider = services.BuildServiceProvider();

var mappify = serviceProvider.GetRequiredService<IMappify>();
```

### Creating a Mapping Profile

Create a class that inherits from `BaseMappingProfile` and implement the `CreateMaps` method to define the mapping:

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

### Mapping Objects

Now you can use the created mapper to map objects:

```csharp
var source = new SourceClass { Property1 = "Value1", Property2 = "Value2" };
var destination = mappify.Map<SourceClass, DestinationClass>(source);
```

### Universal Mapping Method

The library provides a universal method for mapping objects:

```csharp
public TD Map<TD>(object source)
```

This method allows mapping data from an object of any type to a target object of type `TD`. Example usage:

```csharp
var source = new SourceClass { Property1 = "Value1", Property2 = "Value2" };
var destination = mappify.Map<DestinationClass>(source);
```

It also works with collections and arrays. Example usage:

```csharp
var sourceList = new List<SourceClass>
{
    new SourceClass { Property1 = "Value1", Property2 = "Value2" },
    new SourceClass { Property1 = "Value3", Property2 = "Value4" }
};
var destinationList = mappify.Map<List<DestinationClass>>(sourceList);
```

### Mapping Collections

The library also supports mapping collections. Here are a few examples:

#### Example 1: Mapping a List of Objects

```csharp
var sourceList = new List<SourceClass>
{
    new SourceClass { Property1 = "Value1", Property2 = "Value2" },
    new SourceClass { Property1 = "Value3", Property2 = "Value4" }
};

var destinationList = mappify.MapList<DestinationClass>(sourceList);

// destinationList now contains two DestinationClass objects
```

#### Example 2: Mapping an Array of Objects

```csharp
var sourceArray = new SourceClass[]
{
    new SourceClass { Property1 = "Value1", Property2 = "Value2" },
    new SourceClass { Property1 = "Value3", Property2 = "Value4" }
};

var destinationArray = mappify.MapArray<DestinationClass>(sourceArray);

// destinationArray now contains two DestinationClass objects
```

#### Example 3: Mapping a Queue of Objects

```csharp
var sourceQueue = new Queue<SourceClass>();
sourceQueue.Enqueue(new SourceClass { Property1 = "Value1", Property2 = "Value2" });
sourceQueue.Enqueue(new SourceClass { Property1 = "Value3", Property2 = "Value4" });

var destinationQueue = mappify.MapQueue<SourceClass, DestinationClass>(sourceQueue);

// destinationQueue now contains two DestinationClass objects
```

#### Example 4: Mapping a Stack of Objects

```csharp
var sourceStack = new Stack<SourceClass>();
sourceStack.Push(new SourceClass { Property1 = "Value1", Property2 = "Value2" });
sourceStack.Push(new SourceClass { Property1 = "Value3", Property2 = "Value4" });

var destinationStack = mappify.MapStack<SourceClass, DestinationClass>(sourceStack);

// destinationStack now contains two DestinationClass objects
```

#### Example 5: Mapping a Dictionary of Objects

```csharp
var sourceDictionary = new Dictionary<int, SourceClass>
{
    { 1, new SourceClass { Property1 = "Value1", Property2 = "Value2" } },
    { 2, new SourceClass { Property1 = "Value3", Property2 = "Value4" } }
};

var destinationDictionary = mappify.MapDictionary<SourceClass, DestinationClass, int>(sourceDictionary);

// destinationDictionary now contains two DestinationClass objects with the same keys
```

### Mapping from Multiple Sources

There are several overloads for mapping from multiple sources into one object.

```csharp
// Mapping from 1 source.
public TD Map<TS1, TD>(TS1 source1)

// Mapping from 2 sources.
public TD Map<TS1, TS2, TD>(TS1 source1, TS2 source2)

// Mapping from 3 sources.
public TD Map<TS1, TS2, TS3, TD>(TS1 source1, TS2 source2, TS3 source3)

// Mapping from 4 sources.
public TD Map<TS1, TS2, TS3, TS4, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4)

// Mapping from 5 sources.
public TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
```

#### Method 1: Mapping from a Single Source

```csharp
public TD Map<TS1, TD>(TS1 source)
```

This method allows mapping data from a single source `source` of type `TS1` to a target object of type `TD`. It is useful when you need to convert one object to another.

Example usage:

```csharp
var singleSource = new SourceClass { Property1 = "Value1", Property2 = "Value2" };
var singleDestination = mappify.Map<SourceClass, DestinationClass>(singleSource);
```

#### Method 2: Mapping from Multiple Sources

```csharp
public TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
```

This method allows mapping data from multiple sources (up to five) into a target object of type `TD`. This is convenient when you need to combine data from multiple objects into one.

Example usage:

```csharp
var source1 = new SourceClass { Property1 = "Value1" };
var source2 = new OtherSourceClass { OtherProperty = "Value2" };
var source3 = new AdditionalSourceClass { AdditionalProperty = "Value3" };
var source4 = new FourthSourceClass { FourthProperty = "Value4" };
var source5 = new FifthSourceClass { FifthProperty = "Value5" };

// Creating mapping from multiple sources
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


var combinedDestination = Mappify.Map<SourceClass, OtherSourceClass, AdditionalSourceClass, FourthSourceClass, FifthSourceClass, CombinedDestinationClass>(source1, source2, source3, source4, source5);
```

## Exceptions

The library defines exceptions that may occur during mapping errors:

- `MappifyException`: occurs if the mapping for a given type is not defined.

## Contribution

If you want to contribute to the project, please create a fork of the repository, make changes, and create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contacts

If you have any questions or suggestions, you can contact me at lirikvolirvag@gmail.com.

--- 

Let me know if you need any further assistance!