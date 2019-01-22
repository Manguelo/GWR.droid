using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using GodsWayRadio.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;

namespace GodsWayRadio.Droid.Views.Base
{
    [MvxActivityPresentation]
    [Activity(
        Theme = "@style/Theme.AppCompat.Light.NoActionBar",
        LaunchMode = LaunchMode.SingleTop)]

    public class SplitRootView : MvxAppCompatActivity<SplitRootViewModel>
    {
        public DrawerLayout DrawerLayout { get; set; }

        public SplitRootView()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SplitRootView);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
            {
                ViewModel.ShowInitialMenuCommand.Execute();
                ViewModel.ShowDetailCommand.Execute();
            }
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return true;
        }
    }
}