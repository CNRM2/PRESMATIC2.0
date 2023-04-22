namespace PRESMATIC2._0.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }



    private void btnpushpres_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Presupuesto());


    }
}