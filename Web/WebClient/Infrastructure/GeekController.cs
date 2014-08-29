using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;
using CoreServiceProxy.UsersServiceProxy;
using EnumExtensions;
using Enums.Security;
using LogServiceProxy.LogService;

namespace WebClient.Infrastructure
{
    public class GeekController : Controller
    {
        #region System

        protected readonly LogServiceClient _logClient;
        protected readonly UsersServiceClient _usersClient;


        public GeekController()
        {
            _logClient = new LogServiceClient();
            _usersClient = new UsersServiceClient();

        }

        ~GeekController()
        {
            try
            {
                _logClient.Close();
                _usersClient.Close();
            }
            catch (Exception)
            {
                _logClient.Abort();
                _usersClient.Abort();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated && Session["Login"] == null)
            {
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                filterContext.Result = new RedirectResult(Url.Action("Index", "Login", new { area = "" }));
                return;
            }

            base.OnActionExecuting(filterContext);

        }

        #endregion




        public IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

 
    }
}