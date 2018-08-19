using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.DBModel;

namespace HRMS.Controllers
{
    public class DepartmentController : Controller
    {
        HRMSEntities db = new HRMSEntities();
        // GET: Department
        public ActionResult Index()
        {
            FillDropDowns();
            return View();
        }
        void FillDropDowns()
        {
            ViewBag.parentid = new SelectList(db.departments, "DeptID", "Name");
        }
        [HttpPost]
      
        public ActionResult Save(department d)
        {
            if (!ModelState.IsValid)
                return Json(new { ResponseCode = 0, ResponseMessage = "ServerSideModelValidationFailed" });

            Models.Department.Department objDepartment = new Models.Department.Department();
            objDepartment.SaveDepartment(d);
            return RedirectToAction("Index");
            return Json(new { ResponseCode = 3, ResponseMessage = "Error occured while saving conatct us." });
        }
        [HttpPost]
      
        public ActionResult Delete(department d)
        {
            Models.Department.Department objDepartment = new Models.Department.Department();
            objDepartment.DeleteDepartment(d);
            return View();
        }



    }
}