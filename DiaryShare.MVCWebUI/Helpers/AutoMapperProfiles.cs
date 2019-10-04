using AutoMapper;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;

namespace DiaryShare.MVCWebUI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Account, AccountForTrendPanelDto>();
            CreateMap<AccountForTrendPanelDto, Account>();
            CreateMap<Account, AccountForFollowerListDto>();
            CreateMap<DiaryDetailData, DiaryForDetailDto>();
            CreateMap<Account, AccountForProfileDto>();
            CreateMap<Diary, DiaryForProfileDto>();
            CreateMap<Account, AccountForModifyDto>();
            CreateMap<MessagingContentForMessagePage, MessageForMessageContentDto>();
        }
    }
}