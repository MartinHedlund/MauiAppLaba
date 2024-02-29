using MauiAppLaba.ViewModel.LabTwoViewModel;

namespace MauiAppLaba.View;

public partial class AllNotesPageView : ContentPage
{
	public AllNotesPageView(AllNotesPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}