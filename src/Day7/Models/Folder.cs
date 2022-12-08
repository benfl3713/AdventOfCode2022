namespace Day7.Models;

public class Folder : Node
{
    public string Name { get; }

    public Folder(string name)
    {
        Name = name;
    }
}
