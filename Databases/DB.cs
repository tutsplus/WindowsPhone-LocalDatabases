using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    public class UserDataContext : DataContext
    {
        public static string DBConnectionString = @"isostore:/Databases.sdf";
        public UserDataContext(string connectionString)
            : base(connectionString)
        { }
        public Table<User_details> Users
        {
            get
            {
                return this.GetTable<User_details>();
            }
        }
    }
    [Table]
    public class User_details
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
        {
            get;
            set;
        }
        [Column]
        public string user_name
        {
            get;
            set;
        }
        [Column]
        public string user_email
        {
            get;
            set;
        }
    }
}
