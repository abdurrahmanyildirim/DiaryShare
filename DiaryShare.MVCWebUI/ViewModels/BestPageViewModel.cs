using System.Collections.Generic;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.MVCWebUI.Dtos;

namespace DiaryShare.MVCWebUI.ViewModels
{
    public class BestPageViewModel
    {
        public List<AccountForFollowerListDto> MostActiveAccounts { get; set; }
        public List<AccountForFollowerListDto> HasMostFollowerAccounts { get; internal set; }
        public List<MainPageData> HasMostReviewDiaries { get; internal set; }
    }
}