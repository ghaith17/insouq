using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Models
{
    public class JobWanted
    {
        [MaxLength(256)]
        public string JobType { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        public string CV { get; set; }

        [Required]
        public string Gender { get; set; }

        [MaxLength(256)]
        public string Nationality { get; set; }

        [MaxLength(256)]
        public string CurrentLocation { get; set; }

        [MaxLength(256)]
        public string EducationLevel { get; set; }

        [MaxLength(256)]
        public string CurrentCompany { get; set; }

        [MaxLength(256)]
        public string CurrentPosition { get; set; }

        [MaxLength(256)]
        public string WorkExperience { get; set; }

        [MaxLength(256)]
        public string Commitment { get; set; }

        [MaxLength(256)]
        public string NoticePeriod { get; set; }

        [MaxLength(256)]
        public string VisaStatus { get; set; }

        [MaxLength(256)]
        public string CareerLevel { get; set; }

        [MaxLength(256)]
        public string ExpectedMonthlySalary { get; set; }
    }
}
