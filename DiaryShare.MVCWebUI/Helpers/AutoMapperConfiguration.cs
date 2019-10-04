using AutoMapper;

namespace DiaryShare.MVCWebUI.Helpers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperProfiles>();
            });
#pragma warning restore CS0618 // Type or member is obsolete

            //Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}