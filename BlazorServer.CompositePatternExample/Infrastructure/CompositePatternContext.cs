using Microsoft.EntityFrameworkCore;
using BlazorServer.CompositePatternExample.Domain.Models;

namespace BlazorServer.CompositePatternExample.Infrastructure
{
    public class CompositePatternContext : DbContext
    {
        public CompositePatternContext(DbContextOptions<CompositePatternContext> options) : base(options) { }

        DbSet<Domain.Models.Directory> Directories => Set<Domain.Models.Directory>();
        DbSet<Domain.Models.File> Files => Set<Domain.Models.File>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Models.Directory>().HasData(
                new Domain.Models.Directory() { Id = 1, IsRoot = true, Name = "Root", Size = 10 },
                new Domain.Models.Directory() { Id = 2, IsRoot = false, Name = "Documents", Size = 10, DirectoryId = 1 },
                new Domain.Models.Directory() { Id = 3, IsRoot = false, Name = "Pictures", Size = 10, DirectoryId = 1 },
                new Domain.Models.Directory() { Id = 4, IsRoot = false, Name = "Snips", Size = 10, DirectoryId = 3 }
            );

            modelBuilder.Entity<Domain.Models.File>().HasData(
                new Domain.Models.File() { Id = 1, Name = "Root File", Size = 256, DirectoryId = 1 },    
                new Domain.Models.File() { Id = 2, Name = "Document File", Size = 512, DirectoryId = 2 },    
                new Domain.Models.File() { Id = 3, Name = "Picture File", Size = 1028, DirectoryId = 3 },
                new Domain.Models.File() { Id = 4, Name = "Snip File", Size = 1028, DirectoryId = 4 }
            );
        }
    }
}
