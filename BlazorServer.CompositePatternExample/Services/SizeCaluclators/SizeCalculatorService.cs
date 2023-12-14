using BlazorServer.CompositePatternExample.Domain.Models;

namespace BlazorServer.CompositePatternExample.Services.SizeCaluclators
{
    public class SizeCalculatorService<T> : ISizeCalculatorService<T> where T : ModelBase
    {
        public SizeCalculatorService()
        {
            
        }

        public virtual int GetSize(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
