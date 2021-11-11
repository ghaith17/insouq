using System.ComponentModel.DataAnnotations;

namespace insouq.Shared.DTOS.CategoryDTOS
{
    public class UpsertCategoryDTO
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Ar_Name { get; set; }

        [MaxLength(200)]
        public string En_Name { get; set; }

        public int TypeId { get; set; }
    }
}
