using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class ApplyJobDTO
    {
        public int Id { get; set; }

        [Required]
        public string DefaultLanguage { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public IFormFile CvFile { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string CoverNote { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string EducationLevel { get; set; }

        [Required]
        public string CurrentCompany { get; set; }

        [Required]
        public string CurrentPosition { get; set; }

        [Required]
        public string WorkExperience { get; set; }

        [Required]
        public string Commitment { get; set; }

        [Required]
        public string NoticePeriod { get; set; }

        [Required]
        public string VisaStatus { get; set; }

        [Required]
        public string CareerLevel { get; set; }

        [Required]
        public int AdId { get; set; }
    }
}
