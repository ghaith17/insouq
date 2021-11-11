using insouq.Models.Dropdownlists;
using insouq.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class PlateTypeVM
    {
        public List<DLEmirate> Emirates { get; set; }

        public List<DLPlateType> PlateTypes { get; set; }
    }
}
