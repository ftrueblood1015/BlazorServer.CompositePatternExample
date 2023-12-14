using BlazorServer.CompositePatternExample.Repositories;
using BlazorServer.CompositePatternExample.Repositories.Files;

namespace BlazorServer.CompositePatternExample.Services.Files
{
    public class FileService : ServiceBase<Domain.Models.File, IFileRepository>, IFileService
    {
        public FileService(IRepositoryBase<Domain.Models.File> repo) : base(repo)
        {
        }
    }
}
