using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class CommentViewModel
    {
        public string UserName { get; set; }

        public string Comments { get; set; }

        public DateTime Date { get; set; }
    }
}
