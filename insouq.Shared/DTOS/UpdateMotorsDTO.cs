using insouq.Shared.DTOS.AdPictureDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class UpdateMotorsDTO : MotorsAdDTO
    {
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

        public List<AdPictureDTO> Photos { get; set; }

        public string ImagesToDelete { get; set; }
    }
}
