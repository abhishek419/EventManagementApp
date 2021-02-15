using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAcess.DbOpreation
{
    public class CommentService
    {
        public void AddComment(CommentDBO comments, string userid, int eventid)
        {
            int userId = int.Parse(userid);

            using (var context = new ApplicationDbContext())
            {

                CommentDBO comment = new CommentDBO
                {
                    Comments = comments.Comments,
                    EventId = eventid,
                    UserID = userId,
                    Date = DateTime.Now
                };
                context.Comment.Add(comment);
                context.SaveChanges();
            }
        }


        public List<CommentViewModel> GetEventComment(int eventid)
        {
            List<CommentViewModel> model = new List<CommentViewModel>();
            List<CommentDBO> dbcomment = null;
            using (var context = new ApplicationDbContext())
            {
                dbcomment = context.Comment.
                             Where(x => x.EventId == eventid).
                             OrderBy(x => x.Date).ToList();
            };

            foreach (var item in dbcomment)
            {
                if (item.EventId == eventid)
                {
                    CommentViewModel tempModel = new CommentViewModel
                    {
                        Date = item.Date,
                        Comments = item.Comments,
                        UserName = GetUserName(item.UserID)
                    };
                    model.Add(tempModel);
                }
            }

            return model;
        }


        public string GetUserName(int userId)
        {
            ApplicationDbContext databaseContext = new ApplicationDbContext();
            string result = (from User in databaseContext.User
                             where User.UserID == userId
                             select User.UserName).FirstOrDefault();
            return result;
        }
    }
}
