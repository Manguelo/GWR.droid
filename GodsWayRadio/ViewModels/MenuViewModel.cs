using System;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Platform.Platform;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using MvvmCross.Platform;
using System.Linq;
using GodsWayRadio.Models;
using MvvmCross.Platform.UI;

namespace GodsWayRadio.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(IMvxNavigationService navigationService,
                              IMvxTrace trace) : base(navigationService, trace)
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Title = "Instgram", ImageName = "instagram", Color = MvxColor.ParseHexString("#517FA3")},
                new MenuItem { Title = "Twitter", ImageName = "twitter", Color = MvxColor.ParseHexString("#55ACEF")},
                new MenuItem { Title = "Facebook", ImageName = "facebook", Color = MvxColor.ParseHexString("#385B9B")},
                new MenuItem { Title = "YouTube", ImageName = "youtube", Color = MvxColor.ParseHexString("#E32D2A") },
				//new MenuItem { Title = "Alerts", ImageName = "menu-alert" },
				new MenuItem { Title = "Contact", ImageName = "phone", Color = MvxColor.ParseHexString("#0d3982") },
            };
        }


        // Properties

        IList<MenuItem> _menuItems;
        public IList<MenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        // Commands

        private MvxCommand<MenuItem> _selectItemCommand;
        public IMvxCommand SelectItemCommand
        {
            get
            {
                return _selectItemCommand = _selectItemCommand ??
                        new MvxCommand<MenuItem>(item => 
                {
                    Task.Run(async () => { await Navigate(item.Title); });
                });
            }
        }

        // Actions

        async Task Navigate(string item)
        {
            switch (item)
            {
                case ("Instgram"):
                    await _navigationService.Navigate<WebsiteViewModel, WebViewSource>(new WebViewSource
                    {
                        URL = "https://www.instagram.com/godswayradio/",
                        Title = "Instagram"
                    });
                    break;
                case ("Twitter"):
                    await _navigationService.Navigate<WebsiteViewModel, WebViewSource>(new WebViewSource
                    {
                        URL = "https://twitter.com/godswayradio",
                        Title = "Twitter"
                    });
                    break;
                case ("YouTube"):
                    await _navigationService.Navigate<WebsiteViewModel, WebViewSource>(new WebViewSource
                    {
                        URL = "https://www.youtube.com/channel/UCHRWISEfus-AHDcizhlIUcA",
                        Title = "YouTube"
                    });
                    break;
                case ("Facebook"):
                    await _navigationService.Navigate<WebsiteViewModel, WebViewSource>(new WebViewSource
                    {
                        URL = "https://facebook.com/GodsWayRadio",
                        Title = "Facebook"
                    });
                    break;
                case ("Contact"):
                    await _navigationService.Navigate<WebsiteViewModel, WebViewSource>(new WebViewSource
                    {
                        URL = "https://godswayradio.com/about/",
                        Title = "Contact"
                    });
                    break;
               
            }
        }
    }
}
