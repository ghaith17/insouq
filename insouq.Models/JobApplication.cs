using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public string DefaultLanguage { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string CVImageUrl { get; set; }

        public DateTime DOB { get; set; }

        public string CoverNote { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string EducationLevel { get; set; }

        public string CurrentCompany { get; set; }

        public string CurrentPosition { get; set; }

        public string WorkExperience { get; set; }

        public string Commitment { get; set; }

        public string NoticePeriod { get; set; }

        public string VisaStatus { get; set; }

        public string CareerLevel { get; set; }

        // relations

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
