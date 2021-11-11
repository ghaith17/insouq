using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class ServiceAdDTO : CommonAd
    {
        //[Required]
        //public List<IFormFile> Pictures { get; set; }

        //public string MainPhoto { get; set; }

        //public double Price { get; set; }

        //public int TypeId { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategory { get; set; }

        public string PhoneNumber { get; set; }

        public string CarLiftFrom { get; set; }

        public string CarLiftTo { get; set; }
    }
}
