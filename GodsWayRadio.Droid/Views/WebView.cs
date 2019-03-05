
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using GodsWayRadio.Droid.Views.Base;
using GodsWayRadio.Models;
using GodsWayRadio.ViewModels;

namespace GodsWayRadio.Droid.Views
{
    [Activity(Label = "WebsiteViewModel",
               Theme = "@style/Theme.AppCompat.Light.NoActionBar",
               ScreenOrientation = ScreenOrientation.Portrait)]
    public class WebsiteView : BaseViewBackButton<WebsiteViewModel, WebViewSource>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.WebView);

            SetupToolbar(ViewModel.Title);
            SetupWebView();
        }

        private void SetupWebView()
        {
            //ProgressBar progressBar = FindViewById<ProgressBar>(Resource.Id.progress_bar);
            WebView webView = FindViewById<WebView>(Resource.Id.web_view);

            webView.SetWebViewClient(new Android.Webkit.WebViewClient());
            //webView.SetWebChromeClient(new WebChromeClientProgress(progressBar));

            webView.Settings.JavaScriptEnabled = true;
            webView.LoadUrl(ViewModel.URL);

        }


    }
}
