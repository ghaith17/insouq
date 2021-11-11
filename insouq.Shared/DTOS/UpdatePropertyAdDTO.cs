using insouq.Shared.DTOS.AdPictureDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class UpdatePropertyAdDTO : PropertyAdDTO
    {
        public List<AdPictureDTO> Photos { get; set; }

        public string ImagesToDelete { get; set; }
    }

}
