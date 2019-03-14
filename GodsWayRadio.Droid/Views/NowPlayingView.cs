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
using Android.Content.PM;
using System.Collections.Generic;
using MvvmCross.Platform;
using GodsWayRadio.Interfaces;
using System.Threading.Tasks;

namespace GodsWayRadio.Droid.Views
{

    [Activity(Label = "NowPlayingView",
             Theme = "@style/Theme.AppCompat.Light.NoActionBar",
             ScreenOrientation = ScreenOrientation.Portrait)]
    public class NowPlayingView : BaseViewBackButton<NowPlayingViewModel>
    {
        WebView HTML_Player;

        public const string TAG = "wzxv.app.main";
        public const string ActivityName = "wzxv.app.main";

        private NetworkStats _networkStatus;
        private RadioStationService _service;
        private AudioManager _manager;
        private bool _continueTimer = true;
        private bool wait = false;

        Button play;
        Button pause;
        TextView mainLabel;
        TextView subLabel;
        SeekBar volume;
        WebView webView;
        List<string> schedule;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NowPlayingView);
            SetupToolbar("Now Playing");

            play = FindViewById<Button>(Resource.Id.play);
            pause = FindViewById<Button>(Resource.Id.pause);
            mainLabel = FindViewById<TextView>(Resource.Id.label1);
            subLabel = FindViewById<TextView>(Resource.Id.label2);
            volume = FindViewById<SeekBar>(Resource.Id.volume_bar);
            webView = FindViewById<WebView>(Resource.Id.web_view);
            SetUpUI();

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

            Action p = () =>
               {
                   while (_service == null)
                       Console.Out.WriteLine("waiting for service...");
               };
            Task.Run(p).ContinueWith((arg) => OnPlayButtonClick());


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
                    _service.UpdateNotification("Now Playing - God's Way Radio", "WAYG - 104.7");
                }
            }
            else if (_service.IsPlaying)
            {
                play.Alpha = 0.5f;
                pause.Alpha = 1f;
            }
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();

            _continueTimer = false;
        }

        void OnPauseButtonClick()
        {
            if (_service.IsPlaying)
            {
                _service.Stop();
                _service.UpdateNotification("Paused - God's Way Radio", "WAYG - 104.7");
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

        void SetUpUI()
        {
            if (play != null)
                play.Click += (sender, e) => OnPlayButtonClick();

            if (pause != null)
                pause.Click += (sender, e) => OnPauseButtonClick();

            var scheduleClient = new ScheduleClient();
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(scheduleClient);
            webView.LoadUrl("https://godswayradio.com/live/");

            _manager = (AudioManager)Application.Context.GetSystemService(Context.AudioService);
            volume.Max = _manager.GetStreamMaxVolume(Stream.Music);
            volume.Progress = _manager.GetStreamVolume(Stream.Music);
            volume.ProgressChanged += (sender, e) => { _manager.SetStreamVolume(Stream.Music, e.Progress, VolumeNotificationFlags.ShowUi); };

            Mvx.Resolve<IDeviceTimer>().StartTimer(new TimeSpan(0, 0, 3), () => 
            {
                if (!_continueTimer)
                    return false;

                schedule = scheduleClient.GetSchedule();

                if(schedule != null)
                {
                    mainLabel.Text = schedule.ToArray()[0];
                    subLabel.Text = schedule.ToArray()[1];
                    _service.UpdateNotification(schedule.ToArray()[0] + "-" + schedule.ToArray()[1], "God's Way Radio");
                }
                else
                {
                    mainLabel.Text = "God's Way Radio";
                    subLabel.Text = "104.7 WAYG";
                    _service.UpdateNotification("God's Way Radio - 104.7 WAYG", "God's Way Radio");
                }

                return true;
            });
        }
    }
}
