using insouq.Shared.DTOS.AdPictureDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetJobAdDTO
    {
        public int Id { get; set; }

        public int Chates { get; set; }

        public int Views { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string En_Location { get; set; }

        public string Ar_Location { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public int Status { get; set; } // under review or active

        public DateTime PostDate { get; set; }

        public int CategoryId { get; set; }

        public string CategoryArName { get; set; }

        public string CategoryEnName { get; set; }

        public int TypeId { get; set; }

        public int? UserId { get; set; }

        public int? AgentId { get; set; }

        public string Ar_JobType { get; set; }

        public string En_JobType { get; set; }

        public string OtherJobType { get; set; }

        public string PhoneNumber { get; set; }

        public string CV { get; set; }

        public string En_Gender { get; set; }

        public string Ar_Gender { get; set; }

        public string En_Nationality { get; set; }

        public string Ar_Nationality { get; set; }

        public string En_CurrentLocation { get; set; }

        public string Ar_CurrentLocation { get; set; }

        public string En_EducationLevel { get; set; }

        public string Ar_EducationLevel { get; set; }

        //public string CurrentCompany { get; set; }

        public string CurrentPosition { get; set; }

        public string En_WorkExperience { get; set; }

        public string Ar_WorkExperience { get; set; }

        public string En_Commitment { get; set; }

        public string Ar_Commitment { get; set; }

        public string En_NoticePeriod { get; set; }

        public string Ar_NoticePeriod { get; set; }

        public string Ar_VisaStatus { get; set; }

        public string En_VisaStatus { get; set; }

        public string En_CareerLevel { get; set; }

        public string Ar_CareerLevel { get; set; }

        public string ExpectedMonthlySalary { get; set; }

        public string Ar_EmploymentType { get; set; }

        public string En_EmploymentType { get; set; }

        public string En_MinWorkExperience { get; set; }

        public string Ar_MinWorkExperience { get; set; }

        public string En_MinEducationLevel { get; set; }

        public string Ar_MinEducationLevel { get; set; }

        public string CompanyName { get; set; }

        public string UserImage { get; set; }

        public string JobTitle { get; set; }

        public List<AdPictureDTO> Pictures { get; set; }
    }
}
