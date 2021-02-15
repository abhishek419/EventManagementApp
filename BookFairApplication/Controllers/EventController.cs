using BusinessObjects.Model;
using DataAcess.DbOpreation;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookFairApplication.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private EventServices eventsServices = new EventServices();
        private readonly UserServices services = new UserServices();

        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EventsDBO data)
        {
            if (ModelState.IsValid)
            {
                var val = Request.Cookies["Id"].Value;
                bool addEvent = eventsServices.AddEvents(data, val);
                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("", "Some Problem Occured");
            return View();
        }

        public ActionResult MyEvents()
        {
            if (ModelState.IsValid)
            {
                var val = Request.Cookies["Id"].Value;
                return View(eventsServices.MyEvents(val));
            }
            else
            {
                ModelState.AddModelError("", "Some problem Occured");
            }

            return View();
        }



        public ActionResult EventsInvitedTo()
        {
            if (ModelState.IsValid)
            {
                string str = User.Identity.Name;
                return View(eventsServices.InvitedTo(str));
            }
            ModelState.AddModelError("", "Some Problem Occured");
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EventsDBO @event = dbContext.Event.Single(x => x.EventId == id);
            return View(@event);
        }

        [HttpPost]
        public ActionResult Edit(int id, EventsDBO data)
        {
            if (ModelState.IsValid)
            {
                eventsServices.UpdateEvent(id, data);
                return RedirectToAction("MyEvents", "Event");
            }

            ModelState.AddModelError("", "There is some error while editing event");

            return View();
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            EventsDBO @event = dbContext.Event.Single(x => x.EventId == id);
            return View(@event);
        }

        public ActionResult Admin()
        {
            List<EventsDBO> @event = dbContext.Event.ToList();
            return View("AdminView", @event);
        }

        [AllowAnonymous]
        public ActionResult PastEvent()
        {
            dynamic dynamic = new ExpandoObject();
            dynamic.EventsDBO = eventsServices.PastEvent();
            return View(dynamic);
        }

        [AllowAnonymous]
        public ActionResult FutureEvent()
        {
            dynamic dynamic = new ExpandoObject();
            dynamic.EventsDBO = eventsServices.UpcomingEvent();
            return View(dynamic);
        }
    }
}