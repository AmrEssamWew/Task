using DataAcess.Repository.IReporsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Diagnostics;

namespace CRUD_TASK.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
       
        
        IUnitOfWork _UnitOfWork { get; set; }
        IWebHostEnvironment _HostEnvironment { get; set; }

        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _UnitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? Id)
        {
            Product Product = new();
          
            if (Id == 0 || Id == null)
            {
                return View(Product);
            }
            else
            {
               Product = _UnitOfWork.Product.GetFirstOrDefault(i => i.Id == Id);
                return View(Product);
            }
        }



        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
           
                if (obj.Id == 0 || obj.Id == null)
                {


                    _UnitOfWork.Product.Add(obj);
                    TempData["success"] = "The product has been added";
                }
                else
                {


                    _UnitOfWork.Product.Update(obj);
                    TempData["success"] = "The product has been updated";
                }
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }



















        /////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult GetAll()
        {
            var ProductList = _UnitOfWork.Product.GetAll();
            return Json(new { data = ProductList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _UnitOfWork.Product.GetFirstOrDefault(i => i.Id == id);
            if (obj == null)
            {
                return Json(Json(new { success = false, massege = "Error while Deleting" }));
            }
           
            
            _UnitOfWork.Product.Remove(obj);
            _UnitOfWork.Save();
            return Json(Json(new { success = true, massege = "Product has been deleted" }));
        }



    }
}
