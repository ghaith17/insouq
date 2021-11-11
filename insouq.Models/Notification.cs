using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }

        public string ImageUrl { get; set; }

        public string PlateCode { get; set; }

        public int Number { get; set; }
        public string Code { get; set; }
        public string En_Emirate { get; set; }

        public string En_PlateType { get; set; }



        // relations

        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int? AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; }

        [ForeignKey(nameof(OfferId))]
        public AdOffer Offer { get; set; }

        public int? OfferId { get; set; }

        [ForeignKey(nameof(JobApplicationId))]
        public JobApplication JobApplication { get; set; }

        public int? JobApplicationId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }

        public int? AdId { get; set; }

        //public int? AdId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int? CategoryId { get; set; }
    }
}
