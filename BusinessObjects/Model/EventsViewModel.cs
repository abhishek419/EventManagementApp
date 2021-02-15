using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class EventsViewModel
    {
        [Key]
        public int EventId { get; set; }

        public int UserID { get; set; }

        public string Title { get; set; }

        public string TitleOfTheBook { get; set; }

        public DateTime EventDate { get; set; }

        public string TypeOfEvent { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public int Duration { get; set; }

        public string AddPeople { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }
    }
}
