using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Shared.DTOS.UserDTOS
{
    public class UpdateProfileDTO
    {
        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DOB { get; set; }

        [MaxLength(256)]
        public string Nationality { get; set; }

        [MaxLength(256)]
        public string DefaultLocation { get; set; }

        [MaxLength(256)]
        public string DefaultLanguage { get; set; }

        [MaxLength(256)]
        public string CareerLevel { get; set; }

        [MaxLength(256)]
        public string Education { get; set; }

        [MaxLength(256)]
        public string CurrentLocation { get; set; }

        [MaxLength(256)]
        public string CurrentPosition { get; set; }

        [MaxLength(256)]
        public string CurrentCompany { get; set; }

        public IFormFile CVFile { get; set; }

        [MaxLength(256)]
        public string CoverNote { get; set; }

        public IFormFile ProfilePictureFile { get; set; }

        public IFormFile IndustryFile { get; set; }

        public bool HideInfromation { get; set; }

    }
}
