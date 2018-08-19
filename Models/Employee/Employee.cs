using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Core;
using HRMS.DBModel;

namespace HRMS.Models.Employee
{
    public class Employee : IEmployee
    {
        HRMSEntities dbContext = new HRMSEntities();
        public void DelEmp(DBModel.employee emp)
        {
           
        }
         
        public void SaveEmp(DBModel.employee emp)
        {
            dbContext.employees.Add(emp);
            dbContext.SaveChanges();
        }
    }
}