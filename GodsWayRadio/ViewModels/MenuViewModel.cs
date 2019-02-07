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
                new MenuItem { Title = "Instgram", ImageName = "menu_home", Color = MvxColor.ParseHexString("#517FA3")},
                new MenuItem { Title = "Twitter", ImageName = "menu_scanner", Color = MvxColor.ParseHexString("#55ACEF")},
                new MenuItem { Title = "Facebook", ImageName = "menu_document", Color = MvxColor.ParseHexString("#385B9B")},
                new MenuItem { Title = "YouTube", ImageName = "menu_chat", Color = MvxColor.ParseHexString("#E32D2A") },
				//new MenuItem { Title = "Alerts", ImageName = "menu-alert" },
				new MenuItem { Title = "Contact", ImageName = "menu_settings", Color = MvxColor.ParseHexString("#0d3982") },
            };

            //_dialogProvider = dialogProvider;
            //_fileHelper = fileHelper;
            //_messenger = messenger;
            //_userAccessor = userAccessor;

            //UserInfo = userAccessor.UserInfo();
            //Entity = userAccessor.CurrentEntity();
        }


        // Properties

        IList<MenuItem> _menuItems;
        public IList<MenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        //MenuItem _selectedItem;
        //public MenuItem SelectedItem
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        SetProperty(ref _selectedItem, value);
        //        if (_selectedItem == null)
        //            return;
        //        Task.Run(async () =>
        //        {
        //            await Navigate(value.Title);
        //            SelectedItem = null;
        //        });
        //    }
        //}

        //AuthenticationResponse _userInfo;
        //public AuthenticationResponse UserInfo
        //{
        //    get => _userInfo;
        //    set => SetProperty(ref _userInfo, value);
        //}

        //Entity _entity;
        //public Entity Entity
        //{
        //    get => _entity;
        //    set => SetProperty(ref _entity, value);
        //}


        // Commands

        //public IMvxCommand LogoutCommand => new MvxCommand(ShowLogoutPrompt);
        //void ShowLogoutPrompt()
        //{
        //    _dialogProvider.Confirm("Logout", "Are you sure you want to log out of your account?", "Yes", "Cancel", LogoutUser, null);
        //}

        //void LogoutUser()
        //{
        //    _messenger.Publish(new AppMessage(this, MessageKeys.LogOut));
        //    _navigationService.Navigate<LoginViewModel>();
        //}

        //public IMvxCommand SwitchUserCommand => new MvxCommand(SwitchUser);
        //void SwitchUser()
        //{
        //    var entities = UserInfo.Entities;

        //    var users = entities.Select(e =>
        //    {
        //        return new TitledAction
        //        {
        //            ActionTitle = e.Name,
        //            Handler = ChangeDefaultEntity,
        //            Entity = e
        //        };
        //    });
        //    _dialogProvider.ActionSheet("Switch Entities", users);
        //}

        //void ChangeDefaultEntity(Entity entity)
        //{
        //    Settings.Current.CurrentEntity = entity.EntityId;
        //    Entity = entity;

        //    _messenger.Publish(new AppMessage(this, MessageKeys.EntityUpdated));
        //}

        //private MvxCommand<MenuItem> _selectItemCommand;
        //public IMvxCommand SelectItemCommand
        //{
        //    get
        //    {
        //        return _selectItemCommand = _selectItemCommand ??
        //                new MvxCommand<MenuItem>(item => 
        //        {
        //            Task.Run(async () => { await Navigate(item.Title); });
        //        });
        //    }
        //}

        // Actions
        async Task Navigate(string item)
        {
            //switch (item)
            //{
            //    case ("Home"):
            //        await _navigationService.Navigate<MainViewModel>();
            //        break;
            //    case ("Upload Document"):
            //        await _navigationService.Navigate<SimpleCameraViewModel>();
            //        break;
            //    case ("Shoebox"):
            //        await _navigationService.Navigate<ShoeboxViewModel>();
            //        break;
            //    case ("Notes"):
            //        await _navigationService.Navigate<OrganizerViewModel>();
            //        break;
            //    case ("Alerts"):
            //        await _navigationService.Navigate<AlertViewModel>();
            //        break;
            //    case ("Settings"):
            //        await _navigationService.Navigate<SettingsViewModel>();
            //        break;
            //    case ("About"):
            //        await _navigationService.Navigate<BrowserViewModel, BrowserParams>(new BrowserParams
            //        {
            //            Url = PRePAPI.ABOUT,
            //            Title = "About"
            //        });
            //        break;
            //    case ("Help"):
            //        await _navigationService.Navigate<BrowserViewModel, BrowserParams>(new BrowserParams
            //        {
            //            Url = PRePAPI.HELP,
            //            Title = "Help"
            //        });
            //        break;
            //}
        }
    }
}
