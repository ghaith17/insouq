using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class AddJobWanted
    {
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Lat { get; set; }

        [Required]
        public string Lng { get; set; }

        public int CategoryId { get; set; }

        public int AdId { get; set; }

        public string CV { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string CurrentLocation { get; set; }

        public string EducationLevel { get; set; }

        public string CurrentPosition { get; set; }

        public string WorkExperience { get; set; }

        public string Commitment { get; set; }

        public string NoticePeriod { get; set; }

        public string VisaStatus { get; set; }

        public string CareerLevel { get; set; }

        public string ExpectedMonthlySalary { get; set; }

        public IFormFile CvFile { get; set; }
    }
}
