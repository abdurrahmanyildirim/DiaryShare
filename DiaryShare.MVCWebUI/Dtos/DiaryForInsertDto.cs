using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class DiaryForInsertDto
    {
        [Required]
        public int DiaryStatusID { get; set; }

        [Required(ErrorMessage ="Lütfen günlük için bir başlık giriniz."),MaxLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Günlük boş bırakılamaz"), MaxLength(2000, ErrorMessage ="Günlük 2000 karakterden fazla olamaz.")]
        public string DiaryContent { get; set; }
    }
}