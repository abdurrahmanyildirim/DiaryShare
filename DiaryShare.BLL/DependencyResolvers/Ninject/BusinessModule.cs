using DiaryShare.BLL.Abstract;
using DiaryShare.BLL.Concrete;
using DiaryShare.DAL.Abstract;
using DiaryShare.DAL.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountDal>().To<EfAccountDal>().InSingletonScope();
            Bind<IAccountService>().To<AccountManager>().InSingletonScope();

            Bind<IDiaryDal>().To<EfDiaryDal>().InSingletonScope();
            Bind<IDiaryService>().To<DiaryManager>().InSingletonScope();

            Bind<IDiaryStatusDal>().To<EfDiaryStatusDal>().InSingletonScope();
            Bind<IDiaryStatusService>().To<DiaryStatusManager>().InSingletonScope();

            Bind<IFollowerDal>().To<EfFollowerDal>().InSingletonScope();
            Bind<IFollowerService>().To<FollowerManager>().InSingletonScope();

            Bind<IMessageDal>().To<EfMessageDal>().InSingletonScope();
            Bind<IMessageService>().To<MessageManager>().InSingletonScope();

            Bind<IMessageMapDal>().To<EfMessageMapDal>().InSingletonScope();
            Bind<IMessageMapService>().To<MessageMapManager>().InSingletonScope();

            Bind<IReviewDal>().To<EfReviewDal>().InSingletonScope();
            Bind<IReviewService>().To<ReviewManager>().InSingletonScope();

            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
        }
    }
}
