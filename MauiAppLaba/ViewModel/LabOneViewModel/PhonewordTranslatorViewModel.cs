using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppLaba.Inteface;
using MauiAppLaba.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppLaba.ViewModel.LabOneViewModel
{
    public partial class PhonewordTranslatorViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string phoneNumber;
        [ObservableProperty]
        private string callBttText;
        [ObservableProperty]
        private bool isCallBttEnable;
        private readonly IAlertService _alertService;
        public ICommand TranslateComand { get; private set; }
        public ICommand CallBtnComand { get; private set; }

        public PhonewordTranslatorViewModel(IAlertService alertService)
        {
            _alertService = alertService;
            TranslateComand = new RelayCommand(Translate);
            CallBtnComand = new AsyncRelayCommand(CallBtn);
            CallBttText = "Call";
            IsCallBttEnable = false;
        }
        private async Task CallBtn()
        {
            if(await _alertService.ShowConfirmationAsync(
                title: "Наберите номер", 
                message: $"Вы хотите позвонить {phoneNumber}?",
                accept: "Да", 
                cancel: "Нет"))
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(phoneNumber);
            }
        }
        private void Translate()
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                IsCallBttEnable = true;
                CallBttText = "Call " + phoneNumber;
            }
            else
            {
                IsCallBttEnable = false;
                CallBttText = "Call";
            }
        }
    }
}
