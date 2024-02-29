using MauiAppLaba.View;
using MauiAppLaba.ViewModel.LabTwoViewModel;

namespace MauiAppLaba
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PhonewordTranslatorView), typeof(PhonewordTranslatorView));
            Routing.RegisterRoute(nameof(NotePageView), typeof(NotePageView));
            Routing.RegisterRoute(nameof(AllNotesPageView), typeof(AllNotesPageView));
        }
    }
}
