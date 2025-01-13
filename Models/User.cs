using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFusion.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Username"), Unique]
        public string Username { get; set; }

        [Column("Email"), Unique]
        public string Email { get; set; }
    }
}
