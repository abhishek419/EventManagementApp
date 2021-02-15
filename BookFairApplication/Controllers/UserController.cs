using BusinessObjects.Model;
using DataAcess.DbOpreation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookFairApplication.Controllers
{
   
        [AllowAnonymous]
        public class UserController : Controller
        {
            private ApplicationDbContext dbContext = new ApplicationDbContext();
            private UserServices services = new UserServices();
            private RoleOpreation role = new RoleOpreation();

            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public ActionResult Signup()
            {
                return View();

            }

            [HttpPost]
            public ActionResult Signup(UserDBO userdata)
            {

                if (ModelState.IsValid)
                {

                    if (!(services.IsValidUser(userdata)))
                    {
                        bool validNewUser = services.AddUsers(userdata);

                        if (validNewUser)
                        {
                            int id = dbContext.User.Max(x => x.UserID);
                            role.AddRole(id);
                            ViewBag.IsSuccess = "<script>alert('User Added');</script>";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Already Exists");
                    }


                }
                return View();
            }

            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(UserDBO userdata)
            {

                bool isAuthenticated = dbContext.User.Any(x => x.EmailID == userdata.EmailID && x.Password == userdata.Password);
                if (isAuthenticated)
                {
                    UserDBO user = dbContext.User.Single(x => x.EmailID == userdata.EmailID);

                    FormsAuthentication.SetAuthCookie(user.UserID.ToString(), true);
                    var cookie = new HttpCookie("Id", user.UserID.ToString());
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }


                return View();
            }

            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
        }
}