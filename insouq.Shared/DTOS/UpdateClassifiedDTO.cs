using insouq.Shared.DTOS.AdPictureDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class UpdateClassifiedDTO : ClassifiedAdDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategory { get; set; }

        public int? SubTypeId { get; set; }

        public string OtherSubType { get; set; }

        public List<AdPictureDTO> Photos { get; set; }

        public string ImagesToDelete { get; set; }
    }
}
