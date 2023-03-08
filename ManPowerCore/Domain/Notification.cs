using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string NotificationIcon { get; set; }

        public int IsRead { get; set; }

    }
}
