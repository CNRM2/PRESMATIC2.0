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



    private void btnpushpres_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Presupuesto());


    }
    public void NuevoMaterial_Clicked(object sender, EventArgs e)
    {
        // Crear un nuevo objeto Materials con los valores ingresados por el usuario
        Materials nuevoMaterial = new Materials
        {
            N_Material = NbMaterial.Text,
            Precio = Convert.ToDouble(PrecioMat.Text),
            MaterialId = Convert.ToInt32(idMaterial.Text)
        };

        // Agregar el nuevo material a la lista _materiales
        Materials_Repository.AgregarMaterial(nuevoMaterial);

    }
}