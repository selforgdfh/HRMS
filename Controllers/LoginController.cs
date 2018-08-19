using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.DBModel;
using HRMS.Models.User;

namespace HRMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            user obj = new user();
            obj.username = username;
            obj.password = password;

            LoginModel objUserModel = new LoginModel();
            int REsult = objUserModel.ValidateUser(obj);
            if (REsult == 1)
            {
                Session["empid"] = obj.username;
            }
            return Json(REsult);
        }

    
       
    }
}