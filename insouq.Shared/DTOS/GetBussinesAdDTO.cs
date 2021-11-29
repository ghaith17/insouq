using insouq.Shared.DTOS.AdPictureDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetBussinesAdDTO 
    {
        public int Chates { get; set; }

        public int Views { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

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

        public string OtherCategoryName { get; set; }

        public int? SubCategoryId { get; set; }

        public string SubCategoryArName { get; set; }

        public string SubCategoryEnName { get; set; }

        public string OtherSubCategoryName { get; set; }

        public int TypeId { get; set; }

        public int? UserId { get; set; }

        public int? AgentId { get; set; }

        public List<AdPictureDTO> Pictures { get; set; }

        public string UserImage { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsFavorite { get; set; }
    }
}
