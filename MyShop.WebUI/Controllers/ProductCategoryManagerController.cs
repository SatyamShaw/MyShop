using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;
        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            this.context = context;
        }
        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.GetList().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategories = new ProductCategory();
            return View(productCategories);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            ProductCategory productCategoryToEdit = context.Find(id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
                return View(productCategoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string id)
        {
            ProductCategory productCategoryToEdit = context.Find(id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    productCategoryToEdit.CategoryName = productCategory.CategoryName;
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
        }


        public ActionResult Delete(string id)
        {
            ProductCategory productCategoryToDelete = context.Find(id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
                return View(productCategoryToDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            ProductCategory productCatogoryToDelete = context.Find(id);
            if (productCatogoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}