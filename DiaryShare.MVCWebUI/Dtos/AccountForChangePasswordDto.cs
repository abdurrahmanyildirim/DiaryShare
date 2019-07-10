using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class AccountForChangePasswordDto
    {
        [Required(ErrorMessage = "Şifre zorunludur."), MinLength(6, ErrorMessage = "."), DataType(DataType.Password), RegularExpression("^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = "Şifreniz 6 karakterden uzun, harf ve sayı içermesi zorunludur.")]
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}