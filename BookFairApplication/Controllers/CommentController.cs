using BusinessObjects.Model;
using DataAcess.DbOpreation;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace BookFairApplication.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly CommentService service = new CommentService();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CommentDBO comment)
        {
            int eventid = int.Parse(Request.Cookies["id"].Value);

            string userid = HttpContext.User.Identity.Name;

            service.AddComment(comment, userid, eventid);

            return RedirectToAction("Details", "Event", new { id = eventid });
        }


        public ActionResult Show()
        {

            int eventid = int.Parse(Request.Url.Segments.Last());

            dynamic dynamic = new ExpandoObject();
            dynamic.CommentViewModel = service.GetEventComment(eventid);

            return View(dynamic);
        }
    }
}