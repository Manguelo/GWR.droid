using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Util;
using Android.Webkit;
using Android.Widget;
using GodsWayRadio.Interfaces;
using Java.IO;
using Java.Lang;
using Java.Net;
using MvvmCross.Platform;

namespace GodsWayRadio.Droid.Utils
{
    public class ScheduleClient : WebViewClient, IValueCallback
    {
        string _nowPlaying;
        WebView _webView;

        public override void OnPageFinished(WebView view, System.String url)
        {
            _webView = view;
        }

        public List<string> GetSchedule()
        {
            _webView?.EvaluateJavascript("javascript: getSchedule();", this);
            if (_nowPlaying != null)
                return _nowPlaying.Trim('"').Split("-").ToList();
            else
                return new List<string>() { "God's Way Radio", "104.7 WAYG" };
        }

        public void OnReceiveValue(Java.Lang.Object value)
        {
            if(value != null && value.ToString() != _nowPlaying)
                Toast.MakeText(Android.App.Application.Context, value.ToString(), ToastLength.Short).Show();// you will get the value "100

            _nowPlaying = value.ToString();
        }
    }
}
