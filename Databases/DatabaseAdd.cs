using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    class DatabaseAdd
    {
        public void AddUser(String name, String email)
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                User_details du = new User_details();
                du.user_name = name;
                du.user_email = email;
                context.Users.InsertOnSubmit(du);
                context.SubmitChanges();
            }
        }
    }
}
