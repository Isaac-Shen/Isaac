using Isaac.Dtos.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.Fun.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Del(int id)
        {
            return Success(new { message = "删除成功！" });
        }

        [HttpPost]
        public ActionResult UpdateOrAdd(UserInfo userInfo)
        {
            return Success(new { message = "更新成功！" });
        }
    }
}