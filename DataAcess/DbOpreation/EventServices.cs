using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAcess.DbOpreation
{
    public class EventServices
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region Add Events
        public bool AddEvents(EventsDBO userdata, string val)
        {
            int id = int.Parse(val);
            EventsDBO newEvent = new EventsDBO()
            {
                EventId = userdata.EventId,
                UserID = id,
                Title = userdata.Title,
                TitleOfTheBook = userdata.TitleOfTheBook,
                EventDate = userdata.EventDate,
                StartTime = userdata.StartTime,
                TypeOfEvent = userdata.TypeOfEvent,
                Location = userdata.Location,
                Duration = userdata.Duration,
                Description = userdata.Description,
                AddPeople = userdata.AddPeople,
                OtherDetails = userdata.OtherDetails

            };

            db.Event.Add(newEvent);

            int returnValue = db.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        public List<EventsDBO> AllEvents()
        {
            IOrderedQueryable<EventsDBO> events = from e in db.Event
                                                  orderby e.EventDate
                                                  select e;
            var allEvents = events.ToList();
            return allEvents;
        }

        public List<EventsDBO> MyEvents(string val)
        {
            int id = int.Parse(val);
            var events = from e in db.Event
                         where e.UserID == id
                         select e;
            var myEvents = events.ToList();
            return myEvents;
        }

        public List<EventsDBO> InvitedTo(string val)
        {
            var email = db.User.Where(x => x.UserID.ToString() == val).Select(x => x.EmailID).FirstOrDefault();

            var eve = (from e in db.Event select e).ToList();

            var eventsInvitedTo = eve.Where(e => e.AddPeople.Split(',').Contains(email)).Select(e => e);
            return eventsInvitedTo.ToList();
        }

        public void UpdateEvent(int id, EventsDBO data)
        {
            using (db)
            {
                var eve = db.Event.FirstOrDefault(x => x.EventId == id);
                if (eve != null)
                {
                    eve.Title = data.Title;
                    eve.TitleOfTheBook = data.TitleOfTheBook;
                    eve.EventDate = data.EventDate;
                    eve.Location = data.Location;
                    eve.StartTime = data.StartTime;
                    eve.TypeOfEvent = data.TypeOfEvent;
                    eve.Duration = data.Duration;
                    eve.Description = data.Description;
                    eve.AddPeople = data.AddPeople;
                    eve.Description = data.Description;
                    eve.OtherDetails = data.OtherDetails;
                }

                db.SaveChanges();
            }
        }

        public List<EventsDBO> PastEvent()
        {
            List<EventsDBO> events = new List<EventsDBO>();
            events = db.Event.Where(eve => eve.EventDate < DateTime.Now
                                && eve.TypeOfEvent == "Public").ToList();

            return events;
        }

        public List<EventsDBO> UpcomingEvent()
        {
            List<EventsDBO> events = new List<EventsDBO>();
            events = db.Event.Where(eve => eve.EventDate > DateTime.Now
                                && eve.TypeOfEvent == "Public").ToList();

            return events;
        }
    }
}
