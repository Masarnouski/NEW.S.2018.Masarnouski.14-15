using Ninject;
using BLL.Interfaces.Interface;
using BLL.Interfaces.Entities;
using BLL.ServiceImplementation;
using DAL.Repositories;
using DAL.Interfaces.Interface;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IStorage>().To<BinaryStorage>().WithConstructorArgument("storage2.txt");
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IBonusCounter>().To<BonusCounter>();
            kernel.Bind<IIDGenerator>().To<IDGenerator>();
        }
    }
}