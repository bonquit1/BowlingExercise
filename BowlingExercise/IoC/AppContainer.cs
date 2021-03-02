using Autofac;
using BowlingExercise.Services;
using BowlingExercise.ViewModels;
using System;

namespace BowlingExercise.IoC
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            builder.RegisterType<MainPageViewModel>();

            // Services
            builder.RegisterType<BowlingService>().As<IBowlingService>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static T Resolve<T>(NamedParameter param_)
        {
            return _container.Resolve<T>(param_);
        }
    }
}
