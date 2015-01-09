using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    class DatabaseUpdate
    {
        public void UpdateUser(int id, String email, String name)
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_details> entityQuery = from c in context.Users where c.ID == id select c;
                User_details entityToUpdate = entityQuery.FirstOrDefault();
               entityToUpdate.user_name = name;
                entityToUpdate.user_email = email;
                context.SubmitChanges();
            }
        }
        public void UpdateUserToLower()
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_details> entityQuery = from c in context.Users select c;
                IList<User_details> entityToUpdate = entityQuery.ToList();
                foreach(User_details user in entityToUpdate)
                {
                    user.user_name = user.user_name.ToLower();
                }
                context.SubmitChanges();
            }
        }
    }
}
