using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.Models
{
    public class AllAdsVM
    {
        public dynamic Ads { get; set; }

        public int TypeId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int CategoryStatus { get; set; }

        public string SearchLocation { get; set; }
        public string SearchText{ get; set; }

        public bool IsSaved { get; set; }
    }
}
