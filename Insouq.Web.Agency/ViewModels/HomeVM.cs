using insouq.Shared.DTOS;
using insouq.Shared.DTOS.TypeDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.Models
{
    public class HomeVM
    {
        public List<TypeDTO> Types { get; set; }

        public List<GetMotorAdDTO> MotorsAds { get; set; }
        public List<GetPropertyAdDTO> PropertyAds { get; set; }
        public List<GetElectronicAd> ElectronicAds { get; set; }
        public List<GetJobAdDTO> JobsAds { get; set; }
        public List<GetBussinesAdDTO> BusinessAds { get; set; }
        public List<GetClassifiedAdDTO> ClassifiedAds { get; set; }
        public List<GetNumberAdDTO> NumbersAds { get; set; }
        public List<GetServiceAdDTO> ServicesAds { get; set; }
    }
}
