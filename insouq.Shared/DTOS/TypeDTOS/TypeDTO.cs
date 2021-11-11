using insouq.Shared.DTOS.CategoryDTOS;
using System.Collections.Generic;

namespace insouq.Shared.DTOS.TypeDTOS
{
    public class TypeDTO
    {
        public int Id { get; set; }

        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public IEnumerable<CategoryDTO> Categories { get; set; }

    }
}
