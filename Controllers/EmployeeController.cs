using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.DBModel;

namespace HRMS.Controllers
{
    public class EmployeeController : Controller
    {

        // GET: Employee
        HRMSEntities db = new HRMSEntities();
        public ActionResult Index()
        {
            FillDropDowns();
            return View();
        }



        void FillDropDowns()
        {
            ViewBag.ddDept = new SelectList(db.departments, "DeptID", "Name");
            ViewBag.ddLoc = new SelectList(db.locations, "locationscode", "locationsname");
            ViewBag.ddEmpType = new SelectList(db.employeeTypes, "id", "empType");

            ViewBag.ddStatus = new SelectList(db.status, "Code", "name");
            ViewBag.ddStatus = new SelectList(db.status, "Code", "name");
            ViewBag.ddNationality = new SelectList(db.Nationalities, "id", "Name");
            ViewBag.ddBankName = new SelectList(db.banks, "id", "name");
            ViewBag.ddCamp = new SelectList(db.camps, "campid", "campname");
            // return View(ViewData);
        }
        [HttpPost]
        public JsonResult GetEmployeeRecord(employee e)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var result = from employee in db.employees where employee.employeeId == e.employeeId select employee;
            return Json(result);
        }

        public JsonResult Save(employee employee)
        {
            Models.Employee.Employee objEmp = new Models.Employee.Employee();
            objEmp.SaveEmp(employee);
            return Json("1");
        }

        public JsonResult GetEmployee(string sord, int page, int rows, string searchString)
        {
          

            //Setting Paging
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
      

            var Results = from employee A in db.employees
                          join department B in db.departments on A.department equals B.deptid
                          join location C in db.locations on A.location equals C.locationsCode
                          join camp D in db.camps on A.camp equals D.campid
                          join status E in db.status on A.empStatus equals E.Code
                          select new
                          {
                              A.employeeId,
                              A.firstName,
                              A.lastName,
                              Departmentname = B.Name,
                              LocationName = C.locationsName,
                              CampName = D.campName,
                              A.createdDate,
                              StatusName = E.name
                          };

            //Get Total Row Count
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            //Setting Sorting
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.employeeId);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.employeeId);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            //Setting Search
            if (!string.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(m => m.firstName == searchString || m.firstName == searchString);
            }
            //Sending Json Object to View.
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
    }


}