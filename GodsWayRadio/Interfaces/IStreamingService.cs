using System;
namespace GodsWayRadio.Interfaces
{
    public interface IStreamingService
    {
        bool Play();
        void LoadStream();
        bool Pause();
        string GetStatus();
    }
}
