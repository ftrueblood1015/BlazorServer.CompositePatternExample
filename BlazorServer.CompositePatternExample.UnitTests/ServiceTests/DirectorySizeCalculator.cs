using BlazorServer.CompositePatternExample.Repositories.Directory;
using BlazorServer.CompositePatternExample.Repositories.Files;
using BlazorServer.CompositePatternExample.Services.Directories;
using BlazorServer.CompositePatternExample.Services.Files;
using BlazorServer.CompositePatternExample.Services.SizeCaluclators;
using Moq;
using Shouldly;

namespace BlazorServer.CompositePatternExample.UnitTests.ServiceTests
{
    public class DirectorySizeCalculator
    {
        private readonly FileService FileService;
        private readonly DirectoryService DirectoryService;
        private readonly DirectorySizeCalculatorService DirectorySizeCalculatorService;
        public DirectorySizeCalculator()
        {
            var DirectoryRepo = MockBases.MockBase.MockRepo<IDirectoryRepository, Domain.Models.Directory>(
                new List<Domain.Models.Directory>()
                {
                    new Domain.Models.Directory() { Id = 1, IsRoot = true, Name = "Root", Size = 10 },
                    new Domain.Models.Directory() { Id = 2, IsRoot = false, Name = "Documents", Size = 10, DirectoryId = 1 },
                    new Domain.Models.Directory() { Id = 3, IsRoot = false, Name = "Pictures", Size = 10, DirectoryId = 1 },
                    new Domain.Models.Directory() { Id = 4, IsRoot = false, Name = "Snips", Size = 10, DirectoryId = 3 }
                }
            );

            var FileRepo = MockBases.MockBase.MockRepo<IFileRepository, Domain.Models.File>(new List<Domain.Models.File>()
                {
                    new Domain.Models.File() { Id = 1, Name = "Root File", Size = 256, DirectoryId = 1 },
                    new Domain.Models.File() { Id = 2, Name = "Document File", Size = 512, DirectoryId = 2 },
                    new Domain.Models.File() { Id = 3, Name = "Picture File", Size = 1028, DirectoryId = 3 },
                    new Domain.Models.File() { Id = 4, Name = "Snip File", Size = 1028, DirectoryId = 4 }
                }
            );

            DirectoryService = new DirectoryService(DirectoryRepo.Object);
            FileService = new FileService(FileRepo.Object);
            DirectorySizeCalculatorService = new DirectorySizeCalculatorService(DirectoryService, FileService);
        }

        [Test]
        public void Calculate_From_Root()
        {
            var root = DirectoryService.GetById(1);

            var result = DirectorySizeCalculatorService.GetSize(root);

            result.ShouldBe(2864);
        }

        [Test]
        public void Calculate_From_Doucuments()
        {
            var root = DirectoryService.GetById(2);

            var result = DirectorySizeCalculatorService.GetSize(root);

            result.ShouldBe(522);
        }

        [Test]
        public void Calculate_From_Pictures()
        {
            var root = DirectoryService.GetById(3);

            var result = DirectorySizeCalculatorService.GetSize(root);

            result.ShouldBe(2076);
        }

        [Test]
        public void Calculate_From_Snips()
        {
            var root = DirectoryService.GetById(4);

            var result = DirectorySizeCalculatorService.GetSize(root);

            result.ShouldBe(1038);
        }
    }
}
