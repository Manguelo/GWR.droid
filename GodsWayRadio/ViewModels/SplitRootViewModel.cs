using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace GodsWayRadio.ViewModels
{
    public class SplitRootViewModel : BaseViewModel
    {
        public SplitRootViewModel(IMvxNavigationService navigationService,
                                  IMvxTrace logger) : base(navigationService, logger)
        {
            ShowInitialMenuCommand = new MvxAsyncCommand(ShowInitialViewModel);
            ShowDetailCommand = new MvxAsyncCommand(ShowDetailViewModel);
        }

        public IMvxAsyncCommand ShowInitialMenuCommand { get; private set; }

        public IMvxAsyncCommand ShowDetailCommand { get; private set; }

        public override void ViewCreated()
        {
            base.ViewCreated();
            MvxNotifyTask.Create(async () =>
            {
                await ShowInitialViewModel();
                await ShowDetailViewModel();
            });
        }

        async Task ShowInitialViewModel()
        {
            await _navigationService.Navigate<MenuViewModel>();
        }

        async Task ShowDetailViewModel()
        {
            await _navigationService.Navigate<MainViewModel>();
        }
    }
}
