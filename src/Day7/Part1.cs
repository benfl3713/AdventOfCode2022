using Day7.Models;
using File = System.IO.File;

namespace Day7;

public static class Part1
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        TreeNode<Node> fileSystem = new TreeNode<Node>(new Folder("/"));
        TreeNode<Node> currentDirectory = fileSystem;

        List<string> currentCommand = new List<string>();
        foreach (string row in rows)
        {
            if (currentCommand.Count == 0)
            {
                currentCommand.Add(row);
                continue;
            }

            if (row.StartsWith("$ "))
            {
                ProcessCommand(currentCommand, ref currentDirectory, ref fileSystem);
                currentCommand.Clear();
            }
            
            currentCommand.Add(row);
        }
        
        if (currentCommand.Any())
            ProcessCommand(currentCommand, ref currentDirectory, ref fileSystem);

        Dictionary<TreeNode<Node>, int> foldersUnder100Thousand = new Dictionary<TreeNode<Node>, int>();

        fileSystem.TraverseNodes(n =>
        {
            if (n.Value.GetType() != typeof(Folder) || n == fileSystem)
                return;

            var size = GetFolderSize(n);
            if (size < 100000)
                foldersUnder100Thousand.Add(n, size);
        });

        var total = foldersUnder100Thousand.Values.Sum();
        Console.WriteLine($"The total is: {total}");
    }

    private static int GetFolderSize(TreeNode<Node> folder)
    {
        int totalSize = 0;
        folder.Traverse(n =>
        {
            if (n.GetType() == typeof(Models.File))
                totalSize += ((Models.File)n).Size;
        });

        return totalSize;
    }

    private static void ProcessCommand(List<string> rows, ref TreeNode<Node> currentDirectory, ref TreeNode<Node> fileSystem)
    {
        string[] commandWords = rows[0].Split(' ');
        string command = commandWords[1];

        switch (command)
        {
            case "cd":
                ProcessChangeDirectoryCommand(ref currentDirectory, fileSystem, commandWords);
                break;
            case "ls":
                ProcessListDirectoryCommand(rows, currentDirectory);
                break;
        }
    }

    private static void ProcessListDirectoryCommand(List<string> rows, TreeNode<Node> currentDirectory)
    {
        for (int i = 1; i < rows.Count; i++)
        {
            string[] nodeParts = rows[i].Split(' ');
            if (nodeParts[0] == "dir")
            {
                currentDirectory.AddChild(new Folder(nodeParts[1]));
                continue;
            }

            int size = Convert.ToInt32(nodeParts[0]);
            currentDirectory.AddChild(new Models.File(size, nodeParts[1]));
        }
    }

    private static void ProcessChangeDirectoryCommand(ref TreeNode<Node> currentDirectory, TreeNode<Node> fileSystem, string[] commandWords)
    {
        string folder = commandWords[2];
        switch (folder)
        {
            case "folder":
                currentDirectory = fileSystem;
                break;
            case "..":
                currentDirectory = currentDirectory.Parent ?? throw new InvalidOperationException();
                break;
            default:
                if (!currentDirectory.Children.Any(n => IsFolderName(n, folder)))
                    currentDirectory.AddChild(new Folder(folder));

                currentDirectory = currentDirectory.Children.First(n => IsFolderName(n, folder));
                break;
        }
    }

    private static bool IsFolderName(TreeNode<Node> directory, string name) =>
        directory.Value.GetType() == typeof(Folder) && ((Folder)directory.Value).Name == name;
}
