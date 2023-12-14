using System.ComponentModel.DataAnnotations;

namespace BlazorServer.CompositePatternExample.Domain.Models
{
    public class Directory : ModelBase
    {
        [Required]
        public Boolean IsRoot { get; set; }

        public int DirectoryId {  get; set; }

        public Directory? ParentDirectory { get; set; }
    }
}
