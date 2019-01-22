
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using V7 = Android.Support.V7.Widget;

namespace GodsWayRadio.Droid.Views.Base
{
    public abstract class BaseSplitDetailView<TViewModel> : MvxFragment<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected SplitRootView BaseActivity => (SplitRootView)Activity;
        protected V7.Toolbar _toolbar;
        protected MvxActionBarDrawerToggle _drawerToggle;

        protected abstract int FragmentLayoutId { get; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentLayoutId, null);

            _toolbar = view.FindViewById<V7.Toolbar>(Resource.Id.toolbar);
            if (_toolbar != null)
            {
                _toolbar.TextAlignment = TextAlignment.Center;
                _toolbar.SetTitleTextAppearance(Context, Resource.Style.Toolbar_TitleText);
                BaseActivity.SetSupportActionBar(_toolbar);
                BaseActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                _drawerToggle = new MvxActionBarDrawerToggle(
                    Activity,                               // host Activity
                    BaseActivity.DrawerLayout,              // DrawerLayout object
                    _toolbar,                               // nav drawer icon to replace 'Up' caret
                    Resource.String.OpenDrawer,             // "open drawer" description
                    Resource.String.CloseDrawer             // "close drawer" description
                );
                BaseActivity.DrawerLayout.AddDrawerListener(_drawerToggle);
                _drawerToggle.DrawerIndicatorEnabled = true;
            }

            return view;
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (_toolbar != null)
                _drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (_toolbar != null)
                _drawerToggle.SyncState();
        }
    }
}