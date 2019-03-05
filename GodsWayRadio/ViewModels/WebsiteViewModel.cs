using System;
using GodsWayRadio.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Platform.Platform;

namespace GodsWayRadio.ViewModels
{
    public class WebsiteViewModel : BaseViewModel<WebViewSource>
    {

        public WebsiteViewModel(IMvxNavigationService navigationService, IMvxTrace log) : base(navigationService, log)
        {
        }

        public override void Prepare(WebViewSource parameter)
        {
            URL = parameter.URL;
            Title = parameter.Title;
        }

        string _url;
        public string URL
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
