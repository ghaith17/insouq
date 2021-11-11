using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    // Agent and AgencyManager ( same data different roles )
    public class Agent
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Picture { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [MaxLength(256)]
        public string Gender { get; set; }

        public string BrokerNo { get; set; }

        public string WorkNumber { get; set; }

        public string Language { get; set; }

        public bool ShowInformation { get; set; }

        public bool Status { get; set; } // { disabled, active }

        // relations

        public int AgencyId { get; set; }

        [ForeignKey(nameof(AgencyId))]
        public Agency Agency { get; set; }
    }
}
