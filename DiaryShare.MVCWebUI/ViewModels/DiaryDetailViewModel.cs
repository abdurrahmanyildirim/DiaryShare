using System.Collections.Generic;
using DiaryShare.MVCWebUI.Dtos;

namespace DiaryShare.MVCWebUI.ViewModels
{
    public class DiaryDetailViewModel
    {
        public DiaryForDetailDto Diary { get; set; }
        public List<ReviewsForDiariesDto> Reviews { get; set; }
    }
}