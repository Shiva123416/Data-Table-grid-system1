using EcommerceGrid.Data;
using EcommerceGrid.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceGrid.Controllers
{
    public class Form : Controller
    {
        private ApllicationDbContext _db;

        public Form(ApllicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ProductName.ToList());
        }

        //Post Index action method
        //[HttpPost]
        //public IActionResult Index(string producttype)
        //{
        //    var productName = _db.ProductName.Where(c => c.ProductType == producttype).ToList();
        //    return View(productName);
        //}
        //Create Get Action
        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create(ProductName productName)
        {
            if(ModelState.IsValid)
            {
                var serchProduct = _db.ProductName.FirstOrDefault(c => c.ProductType == productName.ProductType);
                if(serchProduct!=null)
                {
                    ViewBag.message = "This Product is already exist";
                    return View(productName);
                }
                _db.ProductName.Add(productName);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productName);
        }

        //Create Get Action
        public ActionResult Update(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var productName = _db.ProductName.Find(id);
            if(productName==null)
            {
                return NotFound();
            }
            return View(productName);
        }

        //Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductName productName)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productName);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productName);
        }

        //Create Get Action
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productName = _db.ProductName.Find(id);
            if (productName == null)
            {
                return NotFound();
            }
            return View(productName);
        }

        //Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id,ProductName productName)
        {
            if(id == null)
            {
                return NotFound();
            }
            if(id!=productName.Id)
            {
                return NotFound();
            }
            var productNames = _db.ProductName.Find(id);
            if(productNames == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productNames);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productName);
        }
    }
}
