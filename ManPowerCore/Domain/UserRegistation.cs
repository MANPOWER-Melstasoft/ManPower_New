using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class UserRegistation
    {
        [DBField("ID")]
        public int UserId { get; set; }

        [DBField("Designation")]
        public string Designation { get; set; }

        [DBField("Date")]
        public DateTime Date { get; set; }

        [DBField("Name")]
        public string Name { get; set; }

        [DBField("Contact_Number")]
        public string ContactNumber { get; set; }

        [DBField("Email")]
        public string Email { get; set; }

        [DBField("User_Name")]
        public string UserName { get; set; }

        [DBField("Password_2")]
        public string Password { get; set; }
    }
}
