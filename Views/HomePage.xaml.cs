using PRESMATIC2._0.Models;
using PRESMATIC2._0.Views;
using PRESMATIC2._0.Database;

namespace PRESMATIC2._0.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void btnpushpres_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Presupuesto());


    }
}