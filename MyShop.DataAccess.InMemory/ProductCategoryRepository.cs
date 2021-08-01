using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("ProductCategory Not Found");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory productCategory = productCategories.Find(p => p.Id == id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("ProductCategory Not Found");
            }
        }

        public IQueryable<ProductCategory> GetListOfProductCategory()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("ProductCategory Not Found");
            }
        }
    }
}
