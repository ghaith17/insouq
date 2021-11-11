using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class AdPicture
    {
        public int Id { get; set; }

        public string ImageURL { get; set; }

        public bool MainPicture { get; set; }

        //relations

        public int AdId { get; set; }
    }
}
