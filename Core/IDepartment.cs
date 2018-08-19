using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.DBModel;

namespace HRMS.Core
{
    public interface IDepartment
    {

        void SaveDepartment(department d);

        void DeleteDepartment(department d);

        void UpdateDepartment(department d);

        void GetDepartments(department d);
    }
}