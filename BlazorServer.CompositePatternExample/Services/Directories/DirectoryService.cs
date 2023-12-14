using BlazorServer.CompositePatternExample.Repositories;
using BlazorServer.CompositePatternExample.Repositories.Directory;

namespace BlazorServer.CompositePatternExample.Services.Directories
{
    public class DirectoryService : ServiceBase<Domain.Models.Directory, IDirectoryRepository>, IDirectoryService
    {
        public DirectoryService(IRepositoryBase<Domain.Models.Directory> repo) : base(repo)
        {
        }
    }
}
