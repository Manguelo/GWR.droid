using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using GodsWayRadio.ViewModels;
using Java.IO;
using Java.Lang;
using MvvmCross.Droid.Views;
using static Android.Media.MediaPlayer;
using Plugin.MediaManager;
using Android.Widget;

namespace GodsWayRadio.Droid.Views
{
    [Activity(Label = "MainView", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class MainView : MvxActivity<MainViewModel>//, IOnPreparedListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainView);
        }
    }
}
