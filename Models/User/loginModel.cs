using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Core;
using HRMS.DBModel;
using HRMS.Helper;

namespace HRMS.Models.User
{/// <summary>
/// 0 - Unknown Error
/// 1 - Grant Access
/// 2 - User Not Exists
/// 3 - Invalid Password
/// 4 - Account Inactive
/// </summary>
    public class LoginModel : IloginModel
    {
        HRMSEntities DbContext = new HRMSEntities();
        public int ValidateUser(user u)
        {
            if (DbContext.users.Where(x => x.username == u.username).Count() == 0)
                return 2;
            if (ValidatePassword(u) == 0)
                return 3;
            if (ValidateEmpStatus(u) == 0)
                return 4;
            return 1;

        }
        public int ValidateDomain(user u)
        {
            throw new NotImplementedException();
        }

        public int ValidateEmpStatus(user u)
        {
            return DbContext.users.Where(x => x.EmpStatus == "A").Count();
        }

        public int ValidatePassword(user u)
        {
            SimpleAES AES = new SimpleAES();
            string passWord = AES.EncryptToString(u.password);
            return DbContext.users.Where(x => x.password == passWord).Count();
        }

        public int ValidatePasswordExpiry(user u)
        {
            throw new NotImplementedException();
        }

        public int ValidateRights(user u)
        {
            throw new NotImplementedException();
        }

        public int ValidateUserExpiry(user u)
        {
            throw new NotImplementedException();
        }
    }
}