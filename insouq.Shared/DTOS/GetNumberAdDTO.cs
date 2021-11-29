using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetNumberAdDTO
    {
        public int Chates { get; set; }

        public int Views { get; set; }
        public int Id { get; set; }

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

        public string En_Emirate { get; set; }

        public string Ar_Emirate { get; set; }

        public string En_PlateType { get; set; }

        public string Ar_PlateType { get; set; }

        public string PlateCode { get; set; }

        public string En_MobileNumberPlan { get; set; }

        public string Ar_MobileNumberPlan { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public string En_Operator { get; set; }

        public string Ar_Operator { get; set; }

        public string Code { get; set; }

        public string Photo { get; set; } // auto generated

        public string Photo2 { get; set; } // auto generated

        public string UserImage { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsFavorite { get; set; }
    }
}
