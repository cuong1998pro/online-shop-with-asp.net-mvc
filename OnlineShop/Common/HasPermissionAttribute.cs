using Model.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Common
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public string RoleID { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/401.cshtml" };
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorize = base.AuthorizeCore(httpContext);
            if (!isAuthorize)
            {
                return false;
            }
            //kiem tra co quyen dang nhap vao khong
            var username = HttpContext.Current.User.Identity.Name;
            var user = new UserDAO().GetByUsername(username);

            string privilegeLevels = string.Join(";", GetCredentialByLoggedUser(username));
            var result = privilegeLevels.Contains(RoleID);
            return result;
        }

        private List<string> GetCredentialByLoggedUser(string username)
        {
            var result = new UserDAO().GetListCredential(username);
            return result;
        }
    }
}