using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class AccountForModifyDto
    {
        [Required(ErrorMessage ="İsim Alanı Boş Bırakılamaz")]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "İsim Alanı Boş Bırakılamaz")]
        [MaxLength(40)]
        public string LastName { get; set; }

        [MaxLength(200,ErrorMessage ="Kişisel bilgi 200 karakterden fazla olamaz.")]
        public string PersonelInfo { get; set; }

        [DisplayName("Resim Yükle")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage ="Lütfen bir resim yükleyiniz.")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}