using System;
using Android.OS;
using GodsWayRadio.Interfaces;

namespace GodsWayRadio.Droid.Utils
{
    public class DeviceTimer : IDeviceTimer
    {
        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            var handler = new Handler(Looper.MainLooper);
            handler.PostDelayed(() =>
            {
                if (callback())
                    StartTimer(interval, callback);

                handler.Dispose();
                handler = null;
            }, (long)interval.TotalMilliseconds);

        }
    }
}
