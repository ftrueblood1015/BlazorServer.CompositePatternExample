using BlazorServer.CompositePatternExample.Composites;
using BlazorServer.CompositePatternExample.Services.Directories;
using BlazorServer.CompositePatternExample.Services.Files;

namespace BlazorServer.CompositePatternExample.Services.SizeCaluclators
{
    public class DirectorySizeCalculatorService : SizeCalculatorService<Domain.Models.Directory>, IDirectorySizeCalculatorService
    {
        private readonly IDirectoryService DirectoryService;
        private readonly IFileService FileService;

        public DirectorySizeCalculatorService(IDirectoryService directoryService, IFileService fileService)
        {
            DirectoryService = directoryService;
            FileService = fileService;
        }

        public override int GetSize(Domain.Models.Directory entity)
        {
            if (entity == null || entity.Name == null || entity.Size == null)
            {
                return 0;
            }

            var root = new DirectoryItem(entity.Name, (int)entity.Size);

            var DirectoryList = new List<Domain.Models.Directory>();
            BuildDirectoryTree(entity, DirectoryList);

            foreach (var directory in DirectoryList)
            {
                var NewDirectoryItem = root;

                if (directory.Id != entity.Id)
                {
                    NewDirectoryItem = new DirectoryItem(directory.Name!, (int)directory.Size!);
                    root.Add(NewDirectoryItem);
                }

                foreach (var file in FileService.Filter(x => x.DirectoryId == directory.Id))
                {
                    var NewFileItem = new FileItem(file.Name!, (int)file.Size!);
                    NewDirectoryItem.Add(NewFileItem);
                }
            }

            return root.GetSize();
        }

        private void BuildDirectoryTree(Domain.Models.Directory directory, List<Domain.Models.Directory> DirectoryList)
        {
            if (DirectoryService == null)
            {
                throw new Exception($"{nameof(DirectoryService)}  is null!");
            }

            if (!DirectoryList.Any(item => item.Id == directory.Id))
            {
                DirectoryList.Add(directory);
            }

            var DirectoriesList = new List<Domain.Models.Directory>();
            DirectoriesList.Add(directory);

            foreach (var dir in DirectoriesList)
            {
                var directories = DirectoryService.Filter(x => x.DirectoryId == dir.Id && x.IsRoot == false && x.Id != dir.Id);

                foreach (var d in directories)
                {
                    BuildDirectoryTree(d, DirectoryList);
                }
            }
        }
    }
}
