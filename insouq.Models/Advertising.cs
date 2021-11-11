using insouq.Models.Dropdownlists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class Advertising
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MinLength(5)]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Phone { get; set; }

        public int AdvertisingBudgetId { get; set; }

        public DLAdvertisingBudjet AdvertisingBudget { get; set; }
        public string Company { get; set; }

        public DateTime Date { get; set; }

    }
}
