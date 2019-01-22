using System;
using Android.App;
using Android.App.Usage;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using MvvmCross.Droid.Views;
using wzxv;
using Android.Content;
using GodsWayRadio.Droid.Utils;
using GodsWayRadio.Droid.Views.Base;
using GodsWayRadio.ViewModels;

namespace GodsWayRadio.Droid.Views
{
    [Activity(Label = "NowPlayingView", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class NowPlayingView : BaseViewBackButton<NowPlayingViewModel>
    {
        WebView HTML_Player;

        public const string TAG = "wzxv.app.main";
        public const string ActivityName = "wzxv.app.main";

        private NetworkStats _networkStatus;
        private RadioStationService _service;
        Button play;
        Button pause;
        WebView webView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NowPlayingView);
            SetupToolbar("Now Playing");

            play = FindViewById<Button>(Resource.Id.play);
            pause = FindViewById<Button>(Resource.Id.pause);
            webView = FindViewById<WebView>(Resource.Id.web_view);

            if (_service == null)
            {
                var intent = new Intent(ApplicationContext, typeof(RadioStationService));
                var connection = new ServiceConnection<RadioStationServiceBinder>(binder =>
                {
                    if (binder != null)
                    {
                        _service = binder.Service;
                        //_service.Playing += OnRadioStationPlaying;
                        _service.StateChanged += OnRadioStationStateChanged;
                        //_service.Error += OnRadioStationError;
                    }
                    else
                    {
                        //_service.Playing -= OnRadioStationPlaying;
                        _service.StateChanged -= OnRadioStationStateChanged;
                        //_service.Error -= OnRadioStationError;
                        _service = null;
                    }
                });

                BindService(intent, connection, Bind.AutoCreate);
            }

            if (play != null)
                play.Click += (sender, e) => OnPlayButtonClick();

            if (pause != null)
                pause.Click += (sender, e) => OnPauseButtonClick();

            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new MyWebViewClient());
            webView.LoadUrl("http://godswayradio.com/wp-content/uploads/2018/08/scheduleV5.js");
        }

        void OnPlayButtonClick()
        {
            if (!_service.IsPlaying)
            {
                var intent = new Intent(ApplicationContext, typeof(RadioStationService)).SetAction(RadioStationService.ActionPlay);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    StartForegroundService(intent);
                }
                else
                {
                    StartService(intent);
                }
            }
        }

        void OnPauseButtonClick()
        {
            if (_service.IsPlaying)
            {
                _service.Stop();
            }
        }

        void OnRadioStationPlaying(object sender, EventArgs e)
        {
            RunOnUiThread(() =>
            {
                //var playing = _schedule.NowPlaying;

                //Controls.PlayingProgress.Configure(c =>
                //{
                //    c.Progress = 0;
                //    c.Max = (int)Math.Ceiling(playing.Duration.TotalSeconds);
                //    c.Progress = (int)Math.Floor(playing.Position.TotalSeconds);
                //});
            });
        }

        void OnNetworkDisconnected()
        {
            if (_service != null && _service.IsPlaying)
            {
                _service.Stop();
            }

            play.Alpha = 1f;
            pause.Alpha = 0.5f;
        }

        void OnRadioStationStateChanged(object sender, EventArgs e)
        {

            if (_service.IsPlaying)
            {
                play.Alpha = 0.5f;
                pause.Alpha = 1f;
            }
            else
            {
                play.Alpha = 1f;
                pause.Alpha = 0.5f;
            }
        }

    }
}
