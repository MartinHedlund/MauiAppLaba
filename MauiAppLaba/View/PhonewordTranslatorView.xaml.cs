using MauiAppLaba.Inteface;
using MauiAppLaba.ViewModel.LabOneViewModel;

namespace MauiAppLaba.View;

public partial class PhonewordTranslatorView : ContentPage
{
	public PhonewordTranslatorView(PhonewordTranslatorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}