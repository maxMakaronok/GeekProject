using System.Web.Mvc;
using System.Web.Security;
using WebClient.Infrastructure;

namespace WebClient.Controllers
{
    public class LoginController : GeekController
    {
        public ActionResult Index()
        {
            return View("_Layout");
        }



        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            //проверка юзера если все ок то добавл его 
            FormsAuthentication.SetAuthCookie(login, true);

            return View("_Layout");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}
