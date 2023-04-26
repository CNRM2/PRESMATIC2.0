using System.Collections.ObjectModel;
using PRESMATIC2._0.Models;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using SearchBar = Microsoft.Maui.Controls.SearchBar;
using PRESMATIC2._0.ViewModels;
using PRESMATIC2._0.Database;

namespace PRESMATIC2._0.Views;


public partial class Presupuesto : ContentPage
{

    ObservableCollection<Materials> elementoSeleccionados;
    public Presupuesto()
    {
        InitializeComponent();


    }

    List<Materials> elementosSeleccionado = new List<Materials>();
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

        var materiales = new ObservableCollection<Materials>(Materials_Repository.SearchMateriales(((SearchBar)sender).Text));
        listMateriales.ItemsSource = materiales;
        SearchBar searchBar = new SearchBar { Placeholder = "Enter search term" };
        searchBar.Unfocused += MySearchBar_Unfocused;
        searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Minimal);

    }
    private void MySearchBar_Unfocused(object sender, FocusEventArgs e)
    {
        var searchBar = (SearchBar)sender;
        if (string.IsNullOrWhiteSpace(searchBar.Text))
        {
            listMateriales.IsVisible = false;
        }
    }


    private void Cargar_Materiales()
    {
        var materiales = new ObservableCollection<Materials>(Materials_Repository.GetMaterials());
        listMateriales.ItemsSource = materiales;


    }

    public void listMateriales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {


        var elementoSeleccionado1 = e.SelectedItem as Materials;
        // Verifica que el elemento seleccionado no se haya agregado previamente
        if (elementoSeleccionado1 != null && !elementosSeleccionado.Contains(elementoSeleccionado1))
        {
            // Agrega el elemento seleccionado a la nueva lista
            elementosSeleccionado.Add(elementoSeleccionado1);

            // Deselecciona el elemento seleccionado
            listMateriales.SelectedItem = null;
            elementoSeleccionados = new ObservableCollection<Materials>(elementosSeleccionado);
            ListaMaterialesSelect.ItemsSource = elementoSeleccionados;
        }


    }


    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }

}