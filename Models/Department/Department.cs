using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Core;
using HRMS.DBModel;

namespace HRMS.Models.Department
{
    public class Department : IDepartment
    {
        HRMSEntities db;

       public Department()
        {
            db = new HRMSEntities();
        }
        public void DeleteDepartment(department d)
        {
            db.departments.Remove(d);
            db.SaveChanges();
        }

        public void GetDepartments(department d)
        {
            throw new NotImplementedException();
        }

        public void SaveDepartment(department d)
        {
            db.departments.Add(d);
            db.SaveChanges();
        }

        public void UpdateDepartment(department d)
        {
            throw new NotImplementedException();
        }
    }
}