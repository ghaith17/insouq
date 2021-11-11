using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class JobAd
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Ar_JobType { get; set; }

        [MaxLength(256)]
        public string En_JobType { get; set; }

        [MaxLength(256)]
        public string CV { get; set; }

        [MaxLength(256)]
        public string En_Gender { get; set; }

        [MaxLength(256)]
        public string Ar_Gender { get; set; }

        [MaxLength(256)]
        public string En_Nationality { get; set; }

        [MaxLength(256)]
        public string Ar_Nationality { get; set; }

        [MaxLength(256)]
        public string En_CurrentLocation { get; set; }

        [MaxLength(256)]
        public string Ar_CurrentLocation { get; set; }

        [MaxLength(256)]
        public string En_EducationLevel { get; set; }

        [MaxLength(256)]
        public string Ar_EducationLevel { get; set; }

        //[MaxLength(256)]
        //public string CurrentCompany { get; set; }

        [MaxLength(256)]
        public string CurrentPosition { get; set; }

        [MaxLength(256)]
        public string En_WorkExperience { get; set; }

        [MaxLength(256)]
        public string Ar_WorkExperience { get; set; }

        [MaxLength(256)]
        public string En_Commitment { get; set; }

        [MaxLength(256)]
        public string Ar_Commitment { get; set; }

        [MaxLength(256)]
        public string En_NoticePeriod { get; set; }

        [MaxLength(256)]
        public string Ar_NoticePeriod { get; set; }

        [MaxLength(256)]
        public string Ar_VisaStatus { get; set; }

        [MaxLength(256)]
        public string En_VisaStatus { get; set; }

        [MaxLength(256)]
        public string En_CareerLevel { get; set; }

        [MaxLength(256)]
        public string Ar_CareerLevel { get; set; }

        [MaxLength(256)]
        public string ExpectedMonthlySalary { get; set; }

        [MaxLength(256)]
        public string Ar_EmploymentType { get; set; }

        [MaxLength(256)]
        public string En_EmploymentType { get; set; }

        [MaxLength(256)]
        public string En_MinWorkExperience { get; set; }

        [MaxLength(256)]
        public string Ar_MinWorkExperience { get; set; }

        [MaxLength(256)]
        public string En_MinEducationLevel { get; set; }

        [MaxLength(256)]
        public string Ar_MinEducationLevel { get; set; }

        [MaxLength(256)]
        public string CompanyName { get; set; }

        [MaxLength(256)]
        public string JobTitle { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}
