using Microsoft.Extensions.Logging;
using FlavorFusion.Data;
using System.IO;

namespace FlavorFusion
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Configurează baza de date
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "FlavorFusion.db3");
            builder.Services.AddSingleton<FlavorFusionDatabase>(_ => new FlavorFusionDatabase(dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
