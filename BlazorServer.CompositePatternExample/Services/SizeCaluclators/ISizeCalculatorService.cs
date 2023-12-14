using BlazorServer.CompositePatternExample.Domain.Models;

namespace BlazorServer.CompositePatternExample.Services.SizeCaluclators
{
    public interface ISizeCalculatorService<T> where T : ModelBase
    {
        public int GetSize(T entity);
    }
}
