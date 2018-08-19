using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.DBModel;

namespace HRMS.Controllers
{
    public class testController : Controller
    {
        private HRMSEntities db = new HRMSEntities();

        // GET: test
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.bank).Include(e => e.department1).Include(e => e.employee2).Include(e => e.employeeType1).Include(e => e.status).Include(e => e.location1).Include(e => e.employee3).Include(e => e.employee4).Include(e => e.Nationality1).Include(e => e.camp1);
            return View(employees.ToList());
        }

        // GET: test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: test/Create
        public ActionResult Create()
        {
            ViewBag.bankName = new SelectList(db.banks, "id", "code");
            ViewBag.department = new SelectList(db.departments, "deptid", "Name");
            ViewBag.createdBy = new SelectList(db.employees, "employeeId", "firstName");
            ViewBag.employeeType = new SelectList(db.employeeTypes, "id", "empType");
            ViewBag.empStatus = new SelectList(db.status, "Code", "name");
            ViewBag.location = new SelectList(db.locations, "locationsCode", "locationsKey");
            ViewBag.ReportingTo = new SelectList(db.employees, "employeeId", "firstName");
            ViewBag.updatedBy = new SelectList(db.employees, "employeeId", "firstName");
            ViewBag.Nationality = new SelectList(db.Nationalities, "id", "Code");
            ViewBag.camp = new SelectList(db.camps, "campid", "campName");
            return View();
        }

        // POST: test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeId,empi_ID_Org,firstName,lastName,department,location,Designation,ReportingTo,employeeType,Religion,visaStatus,empStatus,Nationality,DOB,gender,martialStatus,accomodation,passport,emirateID,bankName,bankAccount,camp,createdBy,createdDate,updatedBy,updateDate,empImage,joining,outsource,remarks")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bankName = new SelectList(db.banks, "id", "code", employee.bankName);
            ViewBag.department = new SelectList(db.departments, "deptid", "Name", employee.department);
            ViewBag.createdBy = new SelectList(db.employees, "employeeId", "firstName", employee.createdBy);
            ViewBag.employeeType = new SelectList(db.employeeTypes, "id", "empType", employee.employeeType);
            ViewBag.empStatus = new SelectList(db.status, "Code", "name", employee.empStatus);
            ViewBag.location = new SelectList(db.locations, "locationsCode", "locationsKey", employee.location);
            ViewBag.ReportingTo = new SelectList(db.employees, "employeeId", "firstName", employee.ReportingTo);
            ViewBag.updatedBy = new SelectList(db.employees, "employeeId", "firstName", employee.updatedBy);
            ViewBag.Nationality = new SelectList(db.Nationalities, "id", "Code", employee.Nationality);
            ViewBag.camp = new SelectList(db.camps, "campid", "campName", employee.camp);
            return View(employee);
        }

        // GET: test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.bankName = new SelectList(db.banks, "id", "code", employee.bankName);
            ViewBag.department = new SelectList(db.departments, "deptid", "Name", employee.department);
            ViewBag.createdBy = new SelectList(db.employees, "employeeId", "firstName", employee.createdBy);
            ViewBag.employeeType = new SelectList(db.employeeTypes, "id", "empType", employee.employeeType);
            ViewBag.empStatus = new SelectList(db.status, "Code", "name", employee.empStatus);
            ViewBag.location = new SelectList(db.locations, "locationsCode", "locationsKey", employee.location);
            ViewBag.ReportingTo = new SelectList(db.employees, "employeeId", "firstName", employee.ReportingTo);
            ViewBag.updatedBy = new SelectList(db.employees, "employeeId", "firstName", employee.updatedBy);
            ViewBag.Nationality = new SelectList(db.Nationalities, "id", "Code", employee.Nationality);
            ViewBag.camp = new SelectList(db.camps, "campid", "campName", employee.camp);
            return View(employee);
        }

        // POST: test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeId,empi_ID_Org,firstName,lastName,department,location,Designation,ReportingTo,employeeType,Religion,visaStatus,empStatus,Nationality,DOB,gender,martialStatus,accomodation,passport,emirateID,bankName,bankAccount,camp,createdBy,createdDate,updatedBy,updateDate,empImage,joining,outsource,remarks")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bankName = new SelectList(db.banks, "id", "code", employee.bankName);
            ViewBag.department = new SelectList(db.departments, "deptid", "Name", employee.department);
            ViewBag.createdBy = new SelectList(db.employees, "employeeId", "firstName", employee.createdBy);
            ViewBag.employeeType = new SelectList(db.employeeTypes, "id", "empType", employee.employeeType);
            ViewBag.empStatus = new SelectList(db.status, "Code", "name", employee.empStatus);
            ViewBag.location = new SelectList(db.locations, "locationsCode", "locationsKey", employee.location);
            ViewBag.ReportingTo = new SelectList(db.employees, "employeeId", "firstName", employee.ReportingTo);
            ViewBag.updatedBy = new SelectList(db.employees, "employeeId", "firstName", employee.updatedBy);
            ViewBag.Nationality = new SelectList(db.Nationalities, "id", "Code", employee.Nationality);
            ViewBag.camp = new SelectList(db.camps, "campid", "campName", employee.camp);
            return View(employee);
        }

        // GET: test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
