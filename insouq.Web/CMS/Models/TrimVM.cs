using insouq.Models.Dropdownlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class TrimVM
    {
        public List<DLMotorMaker> Makers { get; set; }

        public List<DLMotorModel> Models { get; set; }

        public List<DLMotorTrim> Trims { get; set; }
    }
}
