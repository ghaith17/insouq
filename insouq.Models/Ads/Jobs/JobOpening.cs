using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Models
{
    public class JobOpening
    {
        [MaxLength(256)]
        public string JobType { get; set; }

        [MaxLength(256)]
        public string CareerLevel { get; set; }

        [MaxLength(256)]
        public string EmploymentType { get; set; }

        [Required]
        public int MinWorkExperience { get; set; }

        [MaxLength(256)]
        public string MinEducationLevel { get; set; }

        [Required]
        public bool CVRequired { get; set; }

        public double MonthlySalary { get; set; }

        [MaxLength(256)]
        public string Benefits { get; set; }

        // Company Profile

        [MaxLength(256)]
        public string CompanyName { get; set; }

        [MaxLength(256)]
        public string CompanySize { get; set; }

        [MaxLength(256)]
        public string CompanyIndustry { get; set; }

        public bool HideCompanyDetails { get; set; }

    }
}
