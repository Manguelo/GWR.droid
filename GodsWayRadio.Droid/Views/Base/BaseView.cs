using System;
using System.Threading.Tasks;
using Android.Support.V7.Widget;
using Android.Views;
using GodsWayRadio.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;

namespace GodsWayRadio.Droid.Views.Base
{
    public class BaseViewBackButton<T> : MvxAppCompatActivity<T> where T : BaseViewModel
    {
        protected void SetupToolbar(String title, bool homeEnabled = true)
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.TextAlignment = TextAlignment.Center;
            toolbar.SetTitleTextAppearance(this, Resource.Style.Toolbar_TitleText);
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = title;
            SupportActionBar.SetDisplayHomeAsUpEnabled(homeEnabled);
            SupportActionBar.SetHomeButtonEnabled(homeEnabled);

            toolbar.NavigationClick += async delegate
            {
                await ViewModel._navigationService.Close(ViewModel);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return base.OnOptionsItemSelected(item);
        }
    }

    public class BaseViewBackButton<T, K> : MvxAppCompatActivity<T> where T : BaseViewModel<K>
    {
        protected void SetupToolbar(String title, bool homeEnabled = true)
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.TextAlignment = TextAlignment.Center;
            toolbar.SetTitleTextAppearance(this, Resource.Style.Toolbar_TitleText);
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = title;
            SupportActionBar.SetDisplayHomeAsUpEnabled(homeEnabled);
            SupportActionBar.SetHomeButtonEnabled(homeEnabled);

            toolbar.NavigationClick += async delegate
            {
                await ViewModel._navigationService.Close(ViewModel);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return base.OnOptionsItemSelected(item);
        }
    }
}
