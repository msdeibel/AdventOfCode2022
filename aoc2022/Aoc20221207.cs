using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022;

public class Aoc20221207 : AocBase
{
    private const int DiskSpace = 70_000_000;
    private const int UpdateSize = 30_000_000;

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
                if (consoleItem.CommandName.Equals("cd"))
                {
                    if (consoleItem.CommandTarget.Equals("/"))
                    {
                        CurrentFsi = FileSystemItems.First();
                    }
                    else
                    {
                        CurrentFsi = consoleItem.CommandTarget.Equals("..")
                            ? CurrentFsi.Parent
                            : CurrentFsi.Children.Single(c => c.Name.Equals(consoleItem.CommandTarget));
                    }
                }

                // ls
                continue;
            }

            if (consoleItem.IsDir 
                && !consoleItem.Text.Equals("/"))
            {
                if (CurrentFsi.Children.Any(f => f.Name.Equals(consoleItem.Text.Split(' ')[1]))) { continue; }

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
            else if (consoleItem.IsFile
                     && !CurrentFsi.Children.Any(c => c.Name.Equals(consoleItem.Text.Split(' ')[1])))
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
        var unusedSize = DiskSpace - FileSystemItems[0].GetSizeRecursively();
        var requiredSize = UpdateSize - unusedSize;

        return FileSystemItems.Where(f => f.GetSizeRecursively() >= requiredSize).Select(f => f.GetSizeRecursively()).Min();
    }
}


public class ConsoleItem
{
    public string Text { get; }

    public bool IsCommand => Text.StartsWith('$');

    public bool IsDir => Text.Equals("/") || Text.StartsWith("dir");

    public bool IsFile => !IsCommand && !IsDir;

    public ConsoleItem(string consoleLine)
    {
        Text = consoleLine;
    }

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

    public int GetSizeRecursively()
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
                totalSize += child.GetSizeRecursively();
            }
        }


        return totalSize;
    }
}
