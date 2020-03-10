using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using TripleMCalc.Core;

namespace TripleMCalc
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //RegisterNavigationServiceAppStart<MvvmCross.Core.ViewModels.CalculatorViewModel>();
        }

        public App()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<CalculatorViewModel>());

        }
    }
}
