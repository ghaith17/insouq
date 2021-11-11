using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class JobAdDTO : CommonAd
    {
        public string JobType { get; set; }

        public string OtherJobType { get; set; }

        public string PhoneNumber { get; set; }

        public string CV { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string CurrentLocation { get; set; }

        public string EducationLevel { get; set; }

        //public string CurrentCompany { get; set; }

        public string CurrentPosition { get; set; }

        public string WorkExperience { get; set; }

        public string Commitment { get; set; }

        public string NoticePeriod { get; set; }

        public string VisaStatus { get; set; }

        public string CareerLevel { get; set; }

        public string ExpectedMonthlySalary { get; set; }

        public string EmploymentType { get; set; }

        public string MinWorkExperience { get; set; }

        public string MinEducationLevel { get; set; }

        public string CompanyName { get; set; }

        public IFormFile CvFile { get; set; }
    }
}
