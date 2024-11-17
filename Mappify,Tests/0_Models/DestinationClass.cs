namespace Mappify_Tests._0_Models;

public class DestinationClass
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DestinationClass[]? FromSourceArrayToArray { get; set; }

    public DestinationClass[]? FromSourceListToArray { get; set; }

    public List<DestinationClass>? FromSourceListToList { get; set; }

    public List<DestinationClass>? FromSourceArrayToList { get; set; }

    public Dictionary<Guid, DestinationClass>? FromSourceDictionary { get; set; }

    public Queue<DestinationClass>? FromSourceQueue { get; set; }

    public Stack<DestinationClass>? FromSourceStack { get; set; }

    public DestinationClass? FromSource1 { get; set; }

    public DestinationClass? FromSource2 { get; set; }

    public DestinationClass? FromSource3 { get; set; }

    public DestinationClass? FromSource4 { get; set; }

    public DestinationClass? FromSource5 { get; set; }
}