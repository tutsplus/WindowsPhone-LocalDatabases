using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    class DatabaseDelete
    {
        public void DeleteAllUsers() //delete all users
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_details> entityQuery = from c in context.Users select c;
                IList<User_details> entityToDelete = entityQuery.ToList();
                context.Users.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
        public void DeleteUser(String id)//delete user by id
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_details> entityQuery = from c in context.Users where c.ID.Equals(id) select c;
                User_details entityToDelete = entityQuery.FirstOrDefault();
                context.Users.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
    }
}
