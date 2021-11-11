using insouq.Shared.DTOS;
using insouq.Shared.DTOS.UserDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.ViewModels
{
    public class LiveAdsVM
    {
        public UserDTO  User { get; set; }

        public List<AdCountDTO> NoOfAds { get; set; }
    }
}
