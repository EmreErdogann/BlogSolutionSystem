using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.CategoryD
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} boş geçilmemelidir")]
        [MaxLength(70,ErrorMessage ="{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        public string Note { get; set; }
       
    }
}
