namespace BlazorServer.CompositePatternExample.Composites
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public abstract int GetSize();

        public FileSystemItem(string name)
        {
            Name = name;
        }
    }

    public class FileItem : FileSystemItem
    {
        private int Size;

        public FileItem(string name, int size) : base(name)
        {
            Size = size;
        }

        public override int GetSize()
        {
            return Size;
        }
    }

    public class DirectoryItem : FileSystemItem
    {
        private List<FileSystemItem> Items =new List<FileSystemItem>();
        private int Size;
        public DirectoryItem(string name, int size) : base(name)
        {
            Size = size;
        }

        public override int GetSize()
        {
            var SystemSize = Size;

            foreach (var item in Items)
            {
                SystemSize += item.GetSize();
            }

            return SystemSize;
        }

        public void Add(FileSystemItem item)
        {
            Items.Add(item);
        }
    }
}
