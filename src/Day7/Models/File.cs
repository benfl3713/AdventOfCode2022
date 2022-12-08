namespace Day7.Models;

public class File : Node
{
    public int Size { get; }
    public string Name { get; }

    public File(int size, string name)
    {
        Size = size;
        Name = name;
    }
}
