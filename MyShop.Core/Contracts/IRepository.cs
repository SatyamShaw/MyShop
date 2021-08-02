using System.Linq;
using MyShop.Core.Models;

namespace MyShop.Core.Contracts
{
    public interface IRepository<T> where T : BaseModel
    {
        void Commit();
        void Delete(string id);
        T Find(string id);
        IQueryable<T> GetList();
        void Insert(T t);
        void Update(T t);
    }
}