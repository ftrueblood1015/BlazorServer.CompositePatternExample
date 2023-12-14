namespace BlazorServer.CompositePatternExample.Domain.Models
{
    public class File : ModelBase
    {
        public int DirectoryId { get; set; }

        public Directory? ParentDirectory { get; set; }
    }
}
