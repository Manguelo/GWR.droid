
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using GodsWayRadio.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views.Attributes;

namespace GodsWayRadio.Droid.Views
{
    [MvxFragmentPresentation(typeof(SplitRootViewModel), Resource.Id.split_navigation_frame)]
    public class MenuView : MvxFragment<MenuViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.MenuView, null) as NavigationView;
        }
    }
}
