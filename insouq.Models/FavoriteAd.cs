using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class FavoriteAd
    {
        public int Id { get; set; }

        // relations

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int AdId { get; set; }

        [ForeignKey("AdId")]
        public Ad Ad { get; set; }
    }
}
