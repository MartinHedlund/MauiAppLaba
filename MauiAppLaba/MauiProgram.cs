using CommunityToolkit.Maui;
using MauiAppLaba.Inteface;
using MauiAppLaba.Service;
using MauiAppLaba.View;
using MauiAppLaba.ViewModel.LabOneViewModel;
using MauiAppLaba.ViewModel.LabTwoViewModel;
using Microsoft.Extensions.Logging;

namespace MauiAppLaba
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .RegisterContainer()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterContainer(this MauiAppBuilder app) 
        {

            app.Services.AddTransient<PhonewordTranslatorView>();
            app.Services.AddTransient<PhonewordTranslatorViewModel>();

            app.Services.AddScoped<AllNotesPageView>();
            app.Services.AddTransient<AllNotesPageViewModel>();
            app.Services.AddTransient<AboutViewModel>();
            app.Services.AddTransient<AboutPageView>();
            app.Services.AddTransient<NotePageView>();
            app.Services.AddTransient<NoteViewModel>();

            app.Services.AddTransient<IAlertService, AlertService>();

            return app;
        }
    }
}
