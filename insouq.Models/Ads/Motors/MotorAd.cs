using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class MotorAd
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string En_Maker { get; set; }

        [MaxLength(256)]
        public string Ar_Maker { get; set; }

        [MaxLength(256)]
        public string En_Model { get; set; }

        [MaxLength(256)]
        public string Ar_Model { get; set; }

        [MaxLength(256)]
        public string En_Trim { get; set; }

        [MaxLength(256)]
        public string Ar_Trim { get; set; }

        [MaxLength(256)]
        public string En_Color { get; set; }

        [MaxLength(256)]
        public string Ar_Color { get; set; }

        public double? Kilometers { get; set; }

        public int? Year { get; set; }

        [MaxLength(256)]
        public string En_Doors { get; set; }

        [MaxLength(256)]
        public string Ar_Doors { get; set; }

        public bool Warranty { get; set; }

        [MaxLength(256)]
        public string En_Transmission { get; set; }

        [MaxLength(256)]
        public string Ar_Transmission { get; set; }

        [MaxLength(256)]
        public string En_RegionalSpecs { get; set; }

        [MaxLength(256)]
        public string Ar_RegionalSpecs { get; set; }

        [MaxLength(256)]
        public string En_BodyType { get; set; }

        [MaxLength(256)]
        public string Ar_BodyType { get; set; }

        [MaxLength(256)]
        public string En_FuelType { get; set; }

        [MaxLength(256)]
        public string Ar_FuelType { get; set; }

        [MaxLength(256)]
        public string En_NoOfCylinders { get; set; }
        
        [MaxLength(256)]
        public string Ar_NoOfCylinders { get; set; }

        [MaxLength(256)]
        public string En_Horsepower { get; set; } 
        
        [MaxLength(256)]
        public string Ar_Horsepower { get; set; }

        [MaxLength(256)]
        public string En_Condition { get; set; }

        [MaxLength(256)]
        public string Ar_Condition { get; set; }

        [MaxLength(256)]
        public string En_MechanicalCondition { get; set; }

        [MaxLength(256)]
        public string Ar_MechanicalCondition { get; set; }

        public double? Price { get; set; } // min 1000

        [MaxLength(256)]
        public string En_Capacity { get; set; }
        
        [MaxLength(256)]
        public string Ar_Capacity { get; set; }

        [MaxLength(256)]
        public string En_EngineSize { get; set; }
        
        [MaxLength(256)]
        public string Ar_EngineSize { get; set; }

        [MaxLength(256)]
        public string En_Age { get; set; }
        
        [MaxLength(256)]
        public string Ar_Age { get; set; }

        [MaxLength(256)]
        public string En_Usage { get; set; }

        [MaxLength(256)]
        public string Ar_Usage { get; set; }
        
        [MaxLength(256)]
        public string En_Length { get; set; }
        
        [MaxLength(256)]
        public string Ar_Length { get; set; }

        [MaxLength(256)]
        public string En_Wheels { get; set; }

        [MaxLength(256)]
        public string Ar_Wheels { get; set; }

        [MaxLength(256)]
        public string En_SellerType { get; set; }
        
        [MaxLength(256)]
        public string Ar_SellerType { get; set; }
        
        [MaxLength(256)]
        public string En_FinalDriveSystem { get; set; }  
        
        [MaxLength(256)]
        public string Ar_FinalDriveSystem { get; set; }

        [MaxLength(256)]
        public string En_SteeringSide { get; set; }

        [MaxLength(256)]
        public string Ar_SteeringSide { get; set; }

        [MaxLength(256)]
        public string Ar_PartName { get; set; }

        [MaxLength(256)]
        public string En_PartName { get; set; }

        [MaxLength(256)]
        public string NameOfPart { get; set; }

        public int? SubCategoryId { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }

        public string OtherSubCategory { get; set; }

        public int? SubTypeId { get; set; }

        [ForeignKey(nameof(SubTypeId))]
        public SubType SubType { get; set; }

        public string OtherSubType { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}
