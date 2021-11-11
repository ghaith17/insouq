using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string En_Location { get; set; }

        public string Ar_Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public int Status { get; set; } // pending = 2 or deleted = 3 or active=1 or uncompleted =0 or rejected =4 

        public DateTime PostDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        //relations

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; }

        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int? AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; }

        public List<AdPicture> Pictures { get; set; }

        public List<FavoriteAd> Favorites { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
