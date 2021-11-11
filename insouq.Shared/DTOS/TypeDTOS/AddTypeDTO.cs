using System.ComponentModel.DataAnnotations;

namespace insouq.Shared.DTOS.TypeDTOS
{
    public class AddTypeDTO
    {
        [MaxLength(200)]
        public string Ar_Name { get; set; }

        [MaxLength(200)]
        public string En_Name { get; set; }
    }
}
