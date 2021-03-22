using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.UserD
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        public string UserName { get; set; }

        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(11, ErrorMessage = "{0} {1} karakterdan büyük olmamalıdır")]
        [MinLength(11, ErrorMessage = "{0} {1} karakterdan küçük olmamalıdır")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim ")]
        [Required(ErrorMessage = "Lütfen bir {0} ekleyiniz")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string Picture { get; set; }
    }
}
