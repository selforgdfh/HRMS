using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Core;
using HRMS.DBModel;
using HRMS.Models.Location;

namespace HRMS.Controllers
{
    public class LocationController : Controller
    {
        HRMSEntities db = new HRMSEntities();
        // GET: Location
        public ActionResult Index()
        {
            FillDropDowns();
            return View();
        }
        void FillDropDowns()
        {
            ViewBag.ddDept = new SelectList(db.departments, "DeptID", "Name");          
            // return View(ViewData);
        }
        public JsonResult Save()
        {
            return Json("");
        }

        public JsonResult Delete()
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult GetLocation()
        {
            Location objLocation = new Location();
            return Json(objLocation.getTreeView(false, true, true, true, true));
            
        }
    }
}