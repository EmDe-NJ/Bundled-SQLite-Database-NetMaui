using Microsoft.Extensions.Logging;
using BundledSQLiteDbExample.Data;

namespace BundledSQLiteDbExample
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
            //builder.Services.AddSingleton<AppDatabase>(s => ActivatorUtilities.CreateInstance<AppDatabase>(s));
            builder.Services.AddSingleton<AppDatabase>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
