using System;
using System.Threading.Tasks;
using Android.Util;
using Android.Webkit;
using Android.Widget;
using Java.IO;
using Java.Net;

namespace GodsWayRadio.Droid.Utils
{
    public class ScheduleService
    {
        WebView _webView;
        public ScheduleService(WebView wv)
        {
            _webView = wv;
            _webView.Settings.JavaScriptEnabled = true;
            _webView.SetWebViewClient(new MyWebViewClient());
            _webView.SetWebChromeClient(new MyWebChromeClient());
        }

        public void GetSchedule()
        {
            Task.Run(async () =>
            {
                string line = "sample";
                URL url = new URL("https://drive.google.com/uc?export=download&id=1a5o3G_fKK799u3-JeR4sJZW467mkPxlQ");
                BufferedReader read = new BufferedReader(new InputStreamReader(url.OpenStream()));
                while ((line = read.ReadLine()) != null)
                {
                    line = read.ReadLine();
                    System.Console.WriteLine(line);
                }
                read.Close();

                _webView.LoadUrl(line);
            });
           
        }

    }

    public class MyWebViewClient : WebViewClient
    {
        public override void OnPageFinished(WebView view, String url)
        {
            view.EvaluateJavascript("javascript: getSchedule();", new EvaluateBack());
        }
    }

    public class MyWebChromeClient : WebChromeClient
    {
        public bool onJsAlert(WebView view, String url, String message, JsResult result)
        {
            System.Console.WriteLine("Message!!!  " + message);
            Log.Debug("LogTag", message);
            result.Confirm();
            return true;
        }

    }

    public class EvaluateBack : Java.Lang.Object, IValueCallback
    {

        public void OnReceiveValue(Java.Lang.Object value)
        {
            Toast.MakeText(Android.App.Application.Context, value.ToString(), ToastLength.Short).Show();// you will get the value "100"
            var test = value.ToString();
        }
    }
}
