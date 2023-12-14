using BlazorServer.CompositePatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.CompositePatternExample.Repositories.Directory
{
    public class DirectoryRepository : RepositoryBase<Domain.Models.Directory, CompositePatternContext>, IDirectoryRepository
    {
        public DirectoryRepository(CompositePatternContext context) : base(context)
        {
        }

        public override IEnumerable<Domain.Models.Directory> Filter(Func<Domain.Models.Directory, bool> predicate)
        {
            return Context.Set<Domain.Models.Directory>().AsNoTracking().Include(x => x.ParentDirectory).Where(predicate);
        }

        public override IEnumerable<Domain.Models.Directory> GetAll()
        {
            return Context.Set<Domain.Models.Directory>().Include(x => x.ParentDirectory);
        }

        public override Domain.Models.Directory? GetById(int id)
        {
            return Context.Set<Domain.Models.Directory>().Include(x => x.ParentDirectory).FirstOrDefault(x => x.Id == id);
        }
    }
}
