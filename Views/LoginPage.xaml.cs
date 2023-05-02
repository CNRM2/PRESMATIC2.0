using PRESMATIC2._0.Models;
using PRESMATIC2._0.Views;
using PRESMATIC2._0.ViewModels;

namespace PRESMATIC2._0;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        this.BindingContext = new LoginViewModel(this.Navigation);
    }

    public LoginPage(FlyoutPageT flyoutPageT)
    {
        FlyoutPageT = flyoutPageT;
    }

    public FlyoutPageT FlyoutPageT { get; }
}