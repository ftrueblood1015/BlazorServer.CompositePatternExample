using BlazorServer.CompositePatternExample.Domain.Models;
using BlazorServer.CompositePatternExample.Repositories;

namespace BlazorServer.CompositePatternExample.Services
{
    public class ServiceBase<T, TRepo> : IServiceBase<T>
        where T : ModelBase
        where TRepo : IRepositoryBase<T>
    {
        protected IRepositoryBase<T> Repo { get; }

        public ServiceBase(IRepositoryBase<T> repo)
        {
            Repo = repo;
        }

        public T Add(T entity)
        {
            try
            {
                return Repo.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                return Repo.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteById(int entityId)
        {
            try
            {
                return Repo.DeleteById(entityId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            try
            {
                return Repo.Filter(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return Repo.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return Repo.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Update(T entity)
        {
            try
            {
                return Repo.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
