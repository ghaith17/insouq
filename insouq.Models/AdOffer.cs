using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class AdOffer
    {
        public int Id { get; set; }

        public double Price { get; set; }

        //relations

        public int UserId { get; set; }  //user who is apply this offer

        [ForeignKey(nameof(UserId))]
        public User User  { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]

        public Ad Ad { get; set; }

        
    }
}
