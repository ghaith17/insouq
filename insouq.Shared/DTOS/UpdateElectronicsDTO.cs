using insouq.Shared.DTOS.AdPictureDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class UpdateElectronicsDTO : ElectronicAdDTO
    {
        public List<AdPictureDTO> Photos { get; set; }

        public string ImagesToDelete { get; set; }
    }
}
