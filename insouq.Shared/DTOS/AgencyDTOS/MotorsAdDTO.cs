using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AgencyDTOS
{
   public class MotorsAdDTO
    {
        public int CategoryId { get; set; }

        public string Maker { get; set; }

        public string OtherMaker { get; set; }

        public string Model { get; set; }

        public string OtherModel { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategory { get; set; }

        public int? SubTypeId { get; set; }

        public string OtherSubType { get; set; }

        public int Year { get; set; }

        public string Title { get; set; }

        public string Trim { get; set; }

        public string OtherTrim { get; set; }

        public string PartName { get; set; }

        public string OtherPartName { get; set; }

        public int AdId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Lat { get; set; }

        [Required]
        public string Lng { get; set; }

   

        public List<IFormFile> Pictures { get; set; }

        public string MainPhoto { get; set; }

        public string Color { get; set; }

        public double? Kilometers { get; set; }

        public string Doors { get; set; }

        public bool? Warranty { get; set; }

        public string Transmission { get; set; }

        public string RegionalSpecs { get; set; }

        public string BodyType { get; set; }

        public string FuelType { get; set; }

        public string NoOfCylinders { get; set; }

        public string Horsepower { get; set; }

        public string Condition { get; set; }

        public string SellerType { get; set; }

        public string FinalDriveSystem { get; set; }

        public string MechanicalCondition { get; set; }

        public double? Price { get; set; } // min 1000

        public string Capacity { get; set; }

        public string EngineSize { get; set; }

        public string Age { get; set; }

        public string Usage { get; set; }

        public string Length { get; set; }

        public string Wheels { get; set; }

        public string SteeringSide { get; set; }

        public string NameOfPart { get; set; }

        public string PhoneNumber { get; set; }
    }
}
