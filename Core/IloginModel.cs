using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.DBModel;

namespace HRMS.Core
{
    public interface IloginModel
    {
        int ValidateUser(user u);

        int ValidateRights(user u);

        int ValidatePassword(user u);

        int ValidateUserExpiry(user u);

        int ValidatePasswordExpiry(user u);

        int ValidateDomain(user u);

        int ValidateEmpStatus(user u);
    }
}