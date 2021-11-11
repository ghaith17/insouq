using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace insouq.Shared.DTOS.UserDTOS
{
    public class UserDTO
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [MaxLength(256)]
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

        public string CV { get; set; }

        [MaxLength(256)]
        public string CoverNote { get; set; }

        public string ProfilePicture { get; set; }

        [MaxLength(256)]
        public string Industry { get; set; }

        public string City { get; set; }

        public bool HideInfromation { get; set; }

        public bool ExternalLogin { get; set; }

        public DateTime MemberSince { get; set; }

    }
}
