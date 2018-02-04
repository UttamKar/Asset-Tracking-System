using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Interfaces.BLL
{
    public interface ICommonManager<T>:IDisposable where T:class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
    }
}
