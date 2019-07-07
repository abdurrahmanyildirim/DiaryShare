using DiaryShare.MVCWebUI.Dtos;
using System.Collections.Generic;

namespace DiaryShare.MVCWebUI.ViewModels
{
    public class ProfileViewModel
    {
        public AccountForProfileDto AccountInfo { get; set; }
        public List<DiaryForProfileDto> DiariesInfo { get; set; }
        public bool IsOwnProfile { get; set; }
        public bool IsFollower { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
    }
}