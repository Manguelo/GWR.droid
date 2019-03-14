using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using GodsWayRadio.Interfaces;
using GodsWayRadio.Droid.Utils;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.App;

namespace GodsWayRadio.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }
        
        protected override IMvxApplication CreateApp()
        {
            return new GodsWayRadio.App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<IStreamingService>(new StreamingService());
            Mvx.RegisterSingleton<IDeviceTimer>(new DeviceTimer());

        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
        
        protected override IMvxAndroidViewPresenter CreateViewPresenter() => new MvxAppCompatViewPresenter(AndroidViewAssemblies);
    }
}
