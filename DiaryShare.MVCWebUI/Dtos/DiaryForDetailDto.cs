using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class DiaryForDetailDto : AccountBaseDto
    {
        public int DiaryID { get; set; }
        public int AccountID { get; set; }
        public string Title { get; set; }
        public string DiaryContent { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}