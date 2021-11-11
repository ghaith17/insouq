using insouq.Shared.DTOS.AdPictureDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetElectronicAd
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

        public string TypeName { get; set; }

        public int? UserId { get; set; }

        public int? AgentId { get; set; }

        public List<AdPictureDTO> Pictures { get; set; }

        public string En_Age { get; set; }

        public string Ar_Age { get; set; }

        public string En_Usage { get; set; }

        public string Ar_Usage { get; set; }

        public double Price { get; set; } // min 1000

        public string En_Color { get; set; }

        public string Ar_Color { get; set; }

        public bool Warranty { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategory { get; set; }

        public string SubCategoryEn_Name { get; set; }

        public string SubCategoryAr_Name { get; set; }

        public int? SubTypeId { get; set; }

        public string OtherSubType { get; set; }

        public string SubTypeEn_Name { get; set; }

        public string SubTypeAr_Name { get; set; }

        public string UserImage { get; set; }

        public string PhoneNumber { get; set; }
    }
}
