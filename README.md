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

[Examples (GitHub)](https://github.com/Volirvag49/Mappify/tree/main/Mappify.Tests)
## Usage

### Setting Up Dependencies

To start working with the library, you need to register `Mappify` and your mapping profiles in the dependency container. You can do this as follows:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mappify;

var services = new ServiceCollection();
services.AddMappify();

// Choose your style:
//1. Auto: Register all in assembly.
services.AddMappifyProfileForAssembly(typeof(Startup));

//2. Typed.
services.AddMappifyProfile<ObjectMappingProfile>();
services.AddMappifyProfile<OverloadsMappingProfile>();
 
// 2.Parameterized.
services.AddMappifyProfile(typeof(ObjectMappingProfile), typeof(OverloadsMappingProfile));

var serviceProvider = services.BuildServiceProvider();
var mappify = serviceProvider.GetRequiredService<IMappify>();
```

### Creating a Mapping Profile

Create a class that inherits from `BaseMappingProfile` and implement the `CreateMaps` method to define the mapping:

```csharp
 public class ObjectMappingProfile : BaseMappingProfile
 {
     public override void CreateMaps(IMappify Mappify)
     {
         Mappify.CreateMap<SourceClass1, DestinationClass>(source1 => new DestinationClass
         {
             Id = source1.Id,
             Name = source1.Name,
         });
     }
 }
```

### Mapping Objects

Now you can use the created mapper to map objects:

```csharp
 var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
 var dest1 = _mappify.Map<SourceClass1, DestinationClass>(source1);
```

### Universal Mapping Method

The library provides a universal method for mapping objects:

```csharp
public TD Map<TD>(object source)
```
This method allows mapping data from an object of any type to a target object of type `TD`. Example usage:
#### Example 1:  Object to Object
```csharp
  var source1 = new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"};
  var dest1 = _mappify.Map<DestinationClass>(source1);
```

It also works with collections and arrays. Example usage:
#### Example 2:  Collection or Array to  Collection or Array
```csharp
 var source1 = new SourceClass1[]
 {
     new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"},
     new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-2"},
     new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-3"},
     new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-4"},
 };

 var dest1 = _mappify.Map<DestinationClass[]>(source1);
```

### Mapping Collections
The library also supports mapping collections. Here are a few examples:

#### Example 1: Mapping a List of Objects

```csharp
 var source1 = new List<SourceClass1>
 {
     new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-1"},
     new SourceClass1() {Id = Guid.NewGuid(), Name = "Source-2"},
 };

 var dest1 = _mappify.Map<DestinationClass[]>(source1);
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
  var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
  var dest1 = _mappify.Map<SourceClass1, DestinationClass>(source1);
```

#### Method 2: Mapping from Multiple Sources

```csharp
public TD Map<TS1, TS2, TS3, TS4, TS5, TD>(TS1 source1, TS2 source2, TS3 source3, TS4 source4, TS5 source5)
```

This method allows mapping data from multiple sources (up to five) into a target object of type `TD`. This is convenient when you need to combine data from multiple objects into one.

Example usage:

```csharp
 var source1 = new SourceClass1() { Id = Guid.NewGuid(), Name = "Source-1" };
 var source2 = new SourceClass2() { Id = Guid.NewGuid(), Name = "Source-2" };
 var source3 = new SourceClass3() { Id = Guid.NewGuid(), Name = "Source-3" };
 var source4 = new SourceClass4() { Id = Guid.NewGuid(), Name = "Source-4" };
 var source5 = new SourceClass5() { Id = Guid.NewGuid(), Name = "Source-5" };

// OverloadsMappingProfile class
 mappify.CreateMap<SourceClass1, SourceClass2, SourceClass3, SourceClass4, SourceClass5, DestinationClass>((source1, source2, source3, source4, source5) =>
 {
     var dest = new DestinationClass
     {
         FromSource1 = mappify.Map<DestinationClass>(source1),
         FromSource2 = new DestinationClass() { Id = source2.Id, Name = source2.Name},
         FromSource3 = new DestinationClass() { Id = source3.Id, Name = source3.Name },
         FromSource4 = new DestinationClass() { Id = source4.Id, Name = source4.Name },
         FromSource5 = new DestinationClass() { Id = source5.Id, Name = source5.Name },
     };

     return dest;
 });

 var dest1 = _mappify.Map<SourceClass1, SourceClass2, SourceClass3,
     SourceClass4, SourceClass5, DestinationClass>(source1, source2, source3, source4, source5);
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