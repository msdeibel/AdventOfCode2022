namespace aoc2022;

public class Aoc20221207 : AocBase
{
    public FileSystemItem CurrentFsi { get; private set; }

    public List<ConsoleItem> ConsoleItems { get; }

    public List<FileSystemItem> FileSystemItems { get; }

    public Aoc20221207(string rawInput)
        : base(rawInput)
    {
        ConsoleItems = new List<ConsoleItem>();
        FileSystemItems = new List<FileSystemItem>();

        BuildFileSystemLayout();
    }

    public void BuildFileSystemLayout()
    {
        ConsoleItems.Add(new ConsoleItem("/"));

        foreach (var inputRow in InputRows)
        {
            ConsoleItems.Add(new ConsoleItem(inputRow));
        }

        var root = new FileSystemItem()
            {
                Name = "/", 
                IsFile = false, 
                Parent = null, 
                Size = 0, 
                Children = new List<FileSystemItem>()
            };

        FileSystemItems.Add(root);
        CurrentFsi = root;

        foreach (var consoleItem in ConsoleItems)
        {
            if (consoleItem.IsCommand)
            {
                if (!consoleItem.CommandName.Equals("cd")) { continue; }

                CurrentFsi = consoleItem.CommandTarget.Equals("/")
                    ? FileSystemItems.First()
                    : consoleItem.CommandTarget.Equals("..")
                        ? CurrentFsi.Parent
                        : CurrentFsi.Children.Single(c => c.Name.Equals(consoleItem.CommandTarget));
            }

            if (consoleItem.IsDir 
                && !consoleItem.Text.Equals("/"))
            {
                var newDir = new FileSystemItem()
                {
                    Children = new List<FileSystemItem>(),
                    Name = consoleItem.Text.Split(' ')[1],
                    IsFile = false,
                    Parent = CurrentFsi,
                    Size = 0
                };

                FileSystemItems.Add(newDir);
                CurrentFsi.Children.Add(newDir);
            }
            else if (consoleItem.IsFile)
            {
                var newFile = new FileSystemItem()
                {
                    Children = null,
                    Name = consoleItem.Text.Split(' ')[1],
                    IsFile = true,
                    Parent = CurrentFsi,
                    Size = int.Parse(consoleItem.Text.Split(' ')[0])
                };

                FileSystemItems.Add(newFile);
                CurrentFsi.Children.Add(newFile);
            }
        }
    }

    public int GetDiretoryToDeleteSize()
    {
        const int diskSpace = 70_000_000;
        const int updateSize = 30_000_000;

        var unusedSize = diskSpace - FileSystemItems[0].GetDirectorySizeRecursively();
        var requiredSize = updateSize - unusedSize;

        return FileSystemItems.Where(f => f.GetDirectorySizeRecursively() >= requiredSize).Select(f => f.GetDirectorySizeRecursively()).Min();
    }
}


public class ConsoleItem
{
    public ConsoleItem(string consoleLine)
    {
        Text = consoleLine;
    }

    public string Text { get; }

    public bool IsCommand => Text.StartsWith('$');

    public bool IsDir => Text.Equals("/") || Text.StartsWith("dir");

    public bool IsFile => !IsCommand && !IsDir;

    public string CommandName => Text.Split(' ')[1];

    public string CommandTarget => CommandName.Equals("cd") ? Text.Split(' ')[2] : string.Empty;
}

public class FileSystemItem
{
    public bool IsFile { get; set; }

    public string Name { get; set; }

    public FileSystemItem Parent { get; set; }

    public int Size { get; set; }

    public List<FileSystemItem> Children;

    public int GetDirectorySizeRecursively()
    {
        if (IsFile)
        {
            return 0;
        }

        var totalSize = 0;

        foreach (var child in Children)
        {
            if (child.IsFile)
            {
                totalSize += child.Size;
            }
            else
            {
                totalSize += child.GetDirectorySizeRecursively();
            }
        }


        return totalSize;
    }
}
