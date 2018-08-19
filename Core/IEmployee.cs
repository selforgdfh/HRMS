using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Core
{
    public interface IEmployee
    {
        void SaveEmp(DBModel.employee emp);

        void DelEmp(DBModel.employee emp);
        

    }
}