using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class AdStatistic
    {
        public int Id { get; set; }

        public int Type { get; set; } // {Chats, Views, Contact}

        public DateTime Date { get; set; }

        // relations

        public int AdId { get; set; }

        [ForeignKey("AdId")]
        public Ad Ad { get; set; }


        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
