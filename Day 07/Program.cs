var file = File.ReadLines("input.txt");

public interface IItem
{
    public string Name { get; set; }
}

public class Folder : IItem
{
    public string Name { get; set; }
    public List<IItem> Items { get; set; }
}

public class LocalFile : IItem
{
    public string Name { get; set; }
    public int Size { get; set; }
}

