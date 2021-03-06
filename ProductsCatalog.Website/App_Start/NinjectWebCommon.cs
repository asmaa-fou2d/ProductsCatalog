[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProductsCatalog.Website.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProductsCatalog.Website.App_Start.NinjectWebCommon), "Stop")]

namespace ProductsCatalog.Website.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ProductsCatalog.Business.IService;
    using ProductsCatalog.Business.Service;
    using ProductsCatalog.Data;
    using ProductsCatalog.Data.IRepositories;
    using ProductsCatalog.Data.Repositories;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<IUnitOfWork>().To<UnitOfWork>();


                kernel.Bind<IWishListRepository>().To<WishListRepository>();
                kernel.Bind<IWishListService>().To<WishListService>();

                kernel.Bind<IProductRepository>().To<ProductRepository>();
                kernel.Bind<IProductService>().To<ProductService>();

                kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
                kernel.Bind<ICategoryService>().To<CategoryService>();

                kernel.Bind<ISlideshowRepository>().To<SlideshowRepository>();
                kernel.Bind<ISlideshowService>().To<SlideshowService>();


                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}
