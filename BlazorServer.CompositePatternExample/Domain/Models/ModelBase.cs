using System.ComponentModel.DataAnnotations;

namespace BlazorServer.CompositePatternExample.Domain.Models
{
    public class ModelBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Size { get; set; }
    }
}
