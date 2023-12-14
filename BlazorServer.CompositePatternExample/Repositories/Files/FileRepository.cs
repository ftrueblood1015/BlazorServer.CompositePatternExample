using BlazorServer.CompositePatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.CompositePatternExample.Repositories.Files
{
    public class FileRepository : RepositoryBase<Domain.Models.File, CompositePatternContext>, IFileRepository
    {
        public FileRepository(CompositePatternContext context) : base(context)
        {
        }

        public override IEnumerable<Domain.Models.File> Filter(Func<Domain.Models.File, bool> predicate)
        {
            return Context.Set<Domain.Models.File>().AsNoTracking().Include(x => x.ParentDirectory).Where(predicate);
        }

        public override IEnumerable<Domain.Models.File> GetAll()
        {
            return Context.Set<Domain.Models.File>().Include(x => x.ParentDirectory);
        }

        public override Domain.Models.File? GetById(int id)
        {
            return Context.Set<Domain.Models.File>().Include(x => x.ParentDirectory).FirstOrDefault(x => x.Id == id);
        }
    }
}
