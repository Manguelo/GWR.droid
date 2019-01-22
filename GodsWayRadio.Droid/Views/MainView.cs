using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using GodsWayRadio.Droid.Views.Base;
using GodsWayRadio.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Attributes;

namespace GodsWayRadio.Droid.Views
{
    [MvxFragmentPresentation(typeof(SplitRootViewModel), Resource.Id.split_content_frame)]
    public class MainView : BaseSplitDetailView<MainViewModel>//, IOnPreparedListener
    {
        protected override int FragmentLayoutId => Resource.Layout.MainView;
    }
}

