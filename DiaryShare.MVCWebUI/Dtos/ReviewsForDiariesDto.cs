﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class ReviewsForDiariesDto : AccountBaseDto
    {
        public int AccountID { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}