using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class ReviewsForDiariesDto
    {
        public int AccountID { get; set; }
        public string ProfilPhotoPath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}