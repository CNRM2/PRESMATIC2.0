using PRESMATIC2._0.Models;
using System.Formats.Asn1;
using System.Globalization;
using GleamTech.FileUltimate;
using Xamarin.Essentials;
using FilePicker = Microsoft.Maui.Storage.FilePicker;
using CsvHelper;
using FileResult = Microsoft.Maui.Storage.FileResult;
using PickOptions = Microsoft.Maui.Storage.PickOptions;
using FilePickerFileType = Microsoft.Maui.Storage.FilePickerFileType;
using DevicePlatform = Microsoft.Maui.Devices.DevicePlatform;
using System.IO;

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
        Task task = Materials_Repository.AgregarMaterial(nuevoMaterial);

        NbMaterial.Text = string.Empty;
        PrecioMat.Text = string.Empty;
        idMaterial.Text = string.Empty;

    }

    async void CargarMaterial_Clicked(object sender, EventArgs e)
    {
        List<Materials> materialsFromCsv = new List<Materials>();
        //For custom file types            
        var customFileType =
            new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
             { DevicePlatform.iOS, new[] { "csv" } }, // or general UTType values
             { DevicePlatform.Android, new[] { "csv" } },
             { DevicePlatform.WinUI, new[] { ".csv" } },
             { DevicePlatform.Tizen, new[] { "*/*" } },
             { DevicePlatform.macOS, new[] { "csv" } }, // or general UTType values
            });

        try
        {
            var results = await FilePicker.PickMultipleAsync(new PickOptions
            {
                //FileTypes = customFileType
            });

            foreach (var result in results)
            {
                try
                {
                    using (var reader = new StreamReader(result.OpenReadAsync().Result))
                    {
                        // Saltar la primera línea que contiene encabezados
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            var line = await reader.ReadLineAsync();
                            var values = line.Split(',');

                            // Crear una nueva instancia de Material a partir de los valores de la fila
                            var material = new Materials
                            {
                                MaterialId = int.Parse(values[0]),
                                N_Material = values[1],
                                Precio = double.Parse(values[2], CultureInfo.InvariantCulture)
                            };

                            // Agregar la nueva instancia a la lista temporal
                            materialsFromCsv.Add(material);
                        }
                    }
                }
                catch (Exception)
                {
                    // Manejar la excepción al leer el archivo
                    await DisplayAlert("Error", "Error al Cargar el Archivo Cvs", "Aceptar");
                }
            }
        }
        catch (Exception)
        {
            // Manejar la excepción al elegir el archivo
            await DisplayAlert("Error", "Error al Cargar el Archivo Cvs", "Aceptar");
        }
    }


}