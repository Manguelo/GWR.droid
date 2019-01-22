using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.ComponentModel;
using Plugin.MediaManager;
using MvvmCross.Platform;
using GodsWayRadio.Interfaces;
using Plugin.MediaManager.Abstractions.Implementations;
using Plugin.MediaManager.Abstractions.Enums;
using Android.Media;
using static GodsWayRadio.ViewModels.NowPlayingViewModel;
using MvvmCross.Platform.Platform;

namespace GodsWayRadio.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IStreamingService _streamingService;
        IMvxNavigationService _navigationService;

        public MainViewModel(IStreamingService streamingService, IMvxNavigationService navigationService, IMvxTrace trace) : base(navigationService, trace)
        {
            _streamingService = streamingService;
            _navigationService = navigationService;
            _status = "God's Way Radio - 104.7";
            _streamingService.LoadStream();
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        string _status;
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public IMvxCommand NavigateCommand => new MvxCommand(Navigate);
        private void Navigate()
        {
            _navigationService.Navigate<NowPlayingViewModel>();
        }
    }
}