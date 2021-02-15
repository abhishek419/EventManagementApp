using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class EventsDBO
    {
        [Key]
        [Display(Name = "EventId")]
        [Required(ErrorMessage = "Event Id is required")]
        public int EventId { get; set; }

        [Display(Name = "UserID")]
        public int UserID { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Title of the Book")]
        [Required(ErrorMessage = "Book Title  is Required")]
        public string TitleOfTheBook { get; set; }

        [Display(Name = "EventDate")]
        [Required(ErrorMessage = "Date of the Event is Required")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is Required")]
        public string Location { get; set; }

        [Display(Name = "TypeOfEvent")]
        public string TypeOfEvent { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Range(0, 4, ErrorMessage = "Duration should be in 1 to 4hr")]
        public int Duration { get; set; }

        public string AddPeople { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string OtherDetails { get; set; }
    }
}
