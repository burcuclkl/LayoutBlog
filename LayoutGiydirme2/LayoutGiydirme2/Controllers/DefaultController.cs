using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayoutGiydirme2.Models;

namespace LayoutGiydirme2.Controllers
{
    public class DefaultController : Controller
    {
        
        public ActionResult Index()
        {
            NorthwindEntities db = new NorthwindEntities();
            ViewBag.Products = db.Products.ToList();

            return View();
        }
        public ActionResult SupplierList()
        {
            NorthwindEntities db = new NorthwindEntities();
            ViewBag.Supplier = db.Suppliers.ToList();
            
            return View();
        }

        public ActionResult CategoryAdd()
        {
            NorthwindEntities db =new NorthwindEntities();
            ViewBag.Categories = db.Categories.ToList();
            return View();

        }

        public ActionResult SaveCategory(SaveCategoryRequest request)
        {
            Categories categories = new Categories();
            categories.CategoryName = request.Name;
            categories.Description = request.Description;

            NorthwindEntities db = new NorthwindEntities();
            db.Categories.Add(categories);
            db.SaveChanges();
            return RedirectToAction("CategoryAdd");
        }
    }
}