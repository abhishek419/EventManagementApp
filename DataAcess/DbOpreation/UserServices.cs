using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Model;

namespace DataAcess.DbOpreation
{
    public class UserServices
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public bool AddUsers(UserDBO userData)
        {
            UserDBO user = new UserDBO()
            {
                UserID = userData.UserID,
                UserName = userData.UserName,
                EmailID = userData.EmailID,
                Password = userData.Password

            };

            db.User.Add(user);

            int val = db.SaveChanges();

            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsValidUser(UserDBO userdata)
        {
            bool isValidUser = db.User.Any(x => x.EmailID == userdata.EmailID || x.UserName == userdata.UserName);
            if (isValidUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
