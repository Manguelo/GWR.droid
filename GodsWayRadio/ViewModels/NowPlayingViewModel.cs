using System;
using System.Threading.Tasks;
using GodsWayRadio.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace GodsWayRadio.ViewModels
{
    public class NowPlayingViewModel : BaseViewModel
    {
        IStreamingService _streamingService;
        IMvxNavigationService _navigationService;
        IDeviceTimer _deviceTimer;

        public NowPlayingViewModel(IStreamingService streamingService, IMvxNavigationService navigationService, IDeviceTimer deviceTimer, IMvxTrace trace) : base(navigationService, trace)
        {
            _navigationService = navigationService;
            _deviceTimer = deviceTimer;
        }

        public override Task Initialize()
        {
            cancelTimer = false;
            return base.Initialize();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            SetupStatusTimer();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();

            cancelTimer = true;
        }

        bool cancelTimer { get; set; }

        void SetupStatusTimer()
        {
            _deviceTimer.StartTimer(new TimeSpan(0, 0, 3), GetStatus);
        }

        bool GetStatus()
        {
            //Status = _streamingService.GetStatus();
            return cancelTimer;
        }
    }
}