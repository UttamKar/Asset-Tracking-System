using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;

namespace ATS.BLL.Common
{
    public class CommonManager<T>:ICommonManager<T> where T:class
    {
        protected readonly ICommonRepository<T> _repository;

        public CommonManager(ICommonRepository<T> commonRepository)
        {
            _repository = commonRepository;
        }
        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
