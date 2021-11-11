using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class SavedSearch
    {
        public int Id { get; set; }

        public bool Alert { get; set; }

        public bool EmailAlert { get; set; }

        public string Location { get; set; }
        public DateTime Date{ get; set; }

        // relations

        public int ADCategoryId { get; set; }

        [ForeignKey(nameof(ADCategoryId))]
        public Category ADCategory { get; set; }

        public int ADTypeId { get; set; }

        [ForeignKey(nameof(ADTypeId))]
        public Type ADType { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
