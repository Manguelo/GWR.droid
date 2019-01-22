using System;
namespace GodsWayRadio.Interfaces
{
    public interface IDeviceTimer
    {
        void StartTimer(TimeSpan interval, Func<bool> callback);
    }
}
