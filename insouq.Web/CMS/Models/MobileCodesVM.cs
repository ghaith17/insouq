using insouq.Models.Dropdownlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class MobileCodesVM
    {
        public List<DLOperator> Operators { get; set; }

        public List<DLMobileNumberCode> MobileCodes { get; set; }
    }
}
