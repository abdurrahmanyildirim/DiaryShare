using DiaryShare.MVCWebUI.Dtos;
using System.Collections.Generic;

namespace DiaryShare.MVCWebUI.ViewModels
{
    public class ProfileViewModel
    {
        public AccountForProfileDto AccountInfo { get; set; }
        public List<DiaryForProfileDto> DiariesInfo { get; set; }
        public bool IsOwnProfile { get; internal set; }
        public AccountForProfilePictureDto accountForProfilePictureDto { get; set; }
    }
}