using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessObjects.Model
{
    [Table("Comment")]
    public class CommentDBO
    {
       
        [Key]
        public int CommentId { get; set; }

        public int UserID { get; set; }

        public int EventId { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 
    }
}
