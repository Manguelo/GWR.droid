using System;
using GodsWayRadio.Droid;
using Android.Media;
using System.Runtime.CompilerServices;
using GodsWayRadio.Interfaces;

//[assembly: Dependency(typeof(AudioSerivce))]
namespace GodsWayRadio.Droid.Utils
{
    public class StreamingService : IStreamingService
    {
        bool isReady = false;
        MediaPlayer mediaPlayer = new MediaPlayer();

        public void LoadStream()
        {
            if (!isReady)
            {
                //isReady = false;
                mediaPlayer.Reset();
                mediaPlayer.SetDataSource("http://ic2.christiannetcast.com/wayg-fm");
                mediaPlayer.PrepareAsync();
                mediaPlayer.Prepared += (sender, e) => isReady = true;
            }
        }

        public bool Play()
        {
            if (isReady)
            {
                this.mediaPlayer.Start();
            }
            else
            {
                mediaPlayer.Prepared += (sender, e) => mediaPlayer.Start();
            }

            return true;
        }

        public bool Pause()
        {
            if(isReady)
                this.mediaPlayer.Pause();
            else
                mediaPlayer.Prepared += (sender, e) => mediaPlayer.Stop();

            return false;
        }

        public string GetStatus()
        {
            if (mediaPlayer.IsPlaying)
                return "Radio Playing";
            else if (isReady)
                return "Radio Paused";
            else
                return "Radio Loading...";     
        }
    }
}