using insouq.Shared.DTOS.UserDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.ViewModels
{
    public class AdDetailsVM
    {
        public dynamic Ad { get; set; }

        public UserDTO User { get; set; }

        public dynamic SimilarAds { get; set; }

        public int IsProcessDone { get; set; } //IsJobApplied , IsOfferMaked, IsInquiryMaked

        public bool IsInFavorite { get; set; }
    }
}
