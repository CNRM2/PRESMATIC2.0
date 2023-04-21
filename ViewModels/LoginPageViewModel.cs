using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PRESMATIC2._0.Models;
using PRESMATIC2._0.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRESMATIC2._0.ViewModels
{
    public class LoginViewModel
    {
        private string _userName, _password;

        public string Username { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }

        public ICommand RegisterCommand { private set; get; }

        public ICommand LoginCommand { private set; get; }

        private INavigation Navigation;

        public LoginViewModel(INavigation navigation)
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
            Navigation = navigation;
        }

        private async void OnLoginCommand(object obj)
        {
            var loginData = await App.Database.GetLoginDataAsync(Username);
            if (loginData != null)
            {
                if (string.Equals(loginData.Password, Password))
                {
                    await Navigation.PushModalAsync(new HomePage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("failure", "Invalid Password", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("failure", "Invalid Username", "Ok");
            }
        }

        private void OnRegisterCommand(object obj)
        {
            UserInfo lm = new UserInfo();
            lm.Username = Username;
            lm.Password = Password;
            App.Database.SaveLoginDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration uccessful", "Ok");
        }
    }
}
