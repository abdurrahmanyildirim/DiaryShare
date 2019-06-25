using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.ComplexTypes
{
    public class MainPageData
    {
        public int AccountID { get; set; }
        public int DiaryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DiaryContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public string  ProfilPhotoPath { get; set; }
    }
}
