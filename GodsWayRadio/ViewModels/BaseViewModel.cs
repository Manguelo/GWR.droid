using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace GodsWayRadio.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected BaseViewModel(IMvxNavigationService navigationService,
                                IMvxTrace log)
        {
            _navigationService = navigationService;
            _log = log;
        }

        public IMvxNavigationService _navigationService;
        public IMvxTrace _log;

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !isNotBusy;
            }
        }
    }

    public class BaseViewModel<T> : MvxViewModel<T>
    {
        protected BaseViewModel(IMvxNavigationService navigationService,
                                IMvxTrace log)
        {
            _navigationService = navigationService;
            _log = log;
        }

        public IMvxNavigationService _navigationService;
        public IMvxTrace _log;

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !isNotBusy;
            }
        }

        public override void Prepare(T parameter)
        {
            throw new NotImplementedException();
        }
    }

    public class BaseViewModel<T, X> : MvxViewModel<T, X>
    {
        protected BaseViewModel(IMvxNavigationService navigationService,
                                IMvxTrace log)
        {
            _navigationService = navigationService;
            _log = log;
        }

        public IMvxNavigationService _navigationService;
        public IMvxTrace _log;

        public override void Prepare(T parameter)
        {
            throw new NotImplementedException();
        }

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !isNotBusy;
            }
        }

        bool canLoadMore = true;
        public bool CanLoadMore
        {
            get => canLoadMore;
            set => SetProperty(ref canLoadMore, value);
        }
    }
}
