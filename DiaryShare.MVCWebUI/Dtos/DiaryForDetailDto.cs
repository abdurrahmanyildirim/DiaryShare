using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class DiaryForDetailDto
    {
        public int DiaryID { get; set; }
        public int AccountID { get; set; }
        public string DiaryContent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilPhotoPath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}