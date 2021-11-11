using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Models
{
    public class ChatContact
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ContactUserId  { get; set; }

        public int IsBlocked { get; set; }

        public string Status { get; set; } // { Active, Archive }
    }
}
