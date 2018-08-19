using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.DBModel;

namespace HRMS.Core
{
    public interface IuserModel
    {
        List<user> getAllEmpList();

        void saveEmp();

        void updateEmp(user objEmp);

        void deleteEmp(user ObjEmp);
    }
}