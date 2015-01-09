using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    class Users
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
    class FetchDatabase
    {
        public IList<User_details> GetAllUsers()
        {
            IList<User_details> list = null;
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_details> query = from c in context.Users select c;
                list = query.ToList();
            }
            return list;
        }
        public List<Users> getUsers()
        {
            IList<User_details> usrs = this.GetAllUsers();
            List<Users> allmsgs = new List<Users>();
            foreach (User_details m in usrs)
            {
                Users n = new Users();
                n.id = m.ID.ToString();
                n.name = m.user_name;
                n.email = m.user_email;
                allmsgs.Add(n);
            }
            return allmsgs;
        }
    }
}
