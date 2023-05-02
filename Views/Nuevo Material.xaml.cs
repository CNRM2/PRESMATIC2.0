using PRESMATIC2._0.Models;

namespace PRESMATIC2._0.Views;

public partial class Nuevo_Material : ContentPage
{
    public Nuevo_Material()
    {
        InitializeComponent();
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
        App.Current.MainPage.DisplayAlert("Éxito", "Se agregó el nuevo material con éxito", "Aceptar");
        // Agregar el nuevo material a la lista _materiales
        Materials_Repository.AgregarMaterial(nuevoMaterial);

        NbMaterial.Text = string.Empty;
        PrecioMat.Text = string.Empty;
        idMaterial.Text = string.Empty;

    }
}