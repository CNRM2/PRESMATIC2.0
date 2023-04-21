namespace PRESMATIC2._0.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

    }

    private async void Btn_Presupuesto_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page);
    }
}