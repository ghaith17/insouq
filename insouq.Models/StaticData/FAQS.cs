using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Models.StaticData
{
    public class FAQS
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }


        public string Ar_Question { get; set; }
        public string Ar_Answer { get; set; }


        public int isDeleted{ get; set; }

    }

}
