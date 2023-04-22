using System.Collections.ObjectModel;
using PRESMATIC2._0.Models;

namespace PRESMATIC2._0.Views;

public partial class Presupuesto : ContentPage
{
    public Presupuesto()
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

    private void listMateriales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}