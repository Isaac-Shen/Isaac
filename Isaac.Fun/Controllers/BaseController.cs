using Isaac.Comm.Declaration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Isaac.Fun.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            }

            cookie.Value = Session.SessionID;
            HttpContext.Response.AppendCookie(cookie);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Error(int code)
        {
            ViewBag.ErrorCode = code;

            return View(WebPageNames.ErrorPageName);
        }

        protected JsonResult Success(object resultObj, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Json(new { success = true, result = resultObj }, behavior);
        }

        protected JsonResult Failure(object resultObj, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Json(new { success = false, result = resultObj }, behavior);
        }
    }
}