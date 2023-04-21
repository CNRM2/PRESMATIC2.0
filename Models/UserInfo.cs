using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRESMATIC2._0.Models
{
    public class UserInfo
    {
        [PrimaryKey]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
