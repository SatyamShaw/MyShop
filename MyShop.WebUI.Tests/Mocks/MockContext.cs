using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockContext<T> : IRepository<T> where T : BaseModel
    {
        List<T> items;
        private readonly string className;

        public MockContext()
        {
           items = new List<T>();
        }
        public void Commit()
        {
            return;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }
        public void Update(T t)
        {
            T itemToUpdate = items.Find(i => i.Id == t.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate = t;
            }
            else
            {
                throw new Exception(className + " Not Found");
            }
        }

        public T Find(string id)
        {
            T item = items.Find(i => i.Id == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception(className + " Not Found");
            }
        }

        public IQueryable<T> GetList()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            T itemToDelete = items.Find(i => i.Id == id);
            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
            }
            else
            {
                throw new Exception(className + " Not Found");
            }
        }
    }
}