using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DbOpreation
{
    public class RoleOpreation
    {
        public void AddRole(int UserId)
        {
            using (var context = new ApplicationDbContext())
            {
                Role role = new Role()
                {
                    UserID = UserId,
                    UserRole = "User"
                };
                context.Role.Add(role);
                context.SaveChanges();
            }
        }

        public bool GetRole(int _UserId)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var result = (from Role in dbContext.Role
                          where Role.UserID == _UserId
                          select Role.UserRole).ToString();

            if (result == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
