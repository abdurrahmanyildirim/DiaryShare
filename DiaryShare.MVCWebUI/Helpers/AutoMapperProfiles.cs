using AutoMapper;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Account, AccountForTrendPanelDto>();
            CreateMap<AccountForTrendPanelDto, Account>();
        }
    }
}