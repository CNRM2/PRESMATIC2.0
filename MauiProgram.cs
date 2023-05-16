using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.LifecycleEvents;
using PRESMATIC2._0.ViewModels;
using PRESMATIC2._0.Views;
using Syncfusion.Maui.Core.Hosting;

namespace PRESMATIC2._0;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        var builder = MauiApp.CreateBuilder();
        builder


            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();

    }
}
