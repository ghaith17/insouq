using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }

        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public int CategoryId { get; set; }

        public int? TypeId { get; set; }

    }
}
