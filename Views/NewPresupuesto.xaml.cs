using PRESMATIC2._0.Models;
using System.Collections.ObjectModel;

namespace PRESMATIC2._0.Views;

public partial class NewPresupuesto : ContentPage
{
    public NewPresupuesto()
    {
        InitializeComponent();

    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var materiales = new ObservableCollection<Materials>(Materials_Repository.SearchMateriales(((SearchBar)sender).Text));
        listMateriales.ItemsSource = materiales;

    }


    private void Cargar_Materiales()
    {
        var materiales = new ObservableCollection<Materials>(Materials_Repository.GetMaterials());
        listMateriales.ItemsSource = materiales;


    }
    private void Materiales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}
