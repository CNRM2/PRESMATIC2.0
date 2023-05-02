using System.Collections.ObjectModel;
using PRESMATIC2._0.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using SearchBar = Microsoft.Maui.Controls.SearchBar;
using CommunityToolkit;

namespace PRESMATIC2._0.Views
{
    public partial class Presupuesto : ContentPage
    {
        ObservableCollection<Materials> elementoSeleccionados;
        private bool isSearchBarFocused = false;

        public Presupuesto()
        {
            InitializeComponent();
            elementoSeleccionados = new ObservableCollection<Materials>();
            ListaMaterialesSelect.ItemsSource = elementoSeleccionados;
        }

        public void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBar = (SearchBar)sender;
            var searchText = searchBar.Text;

            var materiales = new ObservableCollection<Materials>(Materials_Repository.SearchMateriales(searchText));
            listMateriales.ItemsSource = materiales;

            if (string.IsNullOrWhiteSpace(searchText) || isSearchBarFocused)
            {
                listMateriales.IsVisible = false;
                searchBar.Unfocus();



            }
            else
            {
                listMateriales.IsVisible = true;
            }
        }

        private void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            isSearchBarFocused = true;
            listMateriales.IsVisible = true;
        }

        private void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            isSearchBarFocused = false;
            listMateriales.IsVisible = false;
            listMateriales.Unfocus();
        }

        private void listMateriales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var elementoSeleccionado1 = e.SelectedItem as Materials;
            if (elementoSeleccionado1 != null && !elementoSeleccionados.Contains(elementoSeleccionado1))
            {
                elementoSeleccionados.Add(elementoSeleccionado1);
                ListaMaterialesSelect.ItemsSource = elementoSeleccionados;
                listMateriales.SelectedItem = null;
                listMateriales.Unfocus();

            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            listMateriales.Unfocus();
        }
    }
}
