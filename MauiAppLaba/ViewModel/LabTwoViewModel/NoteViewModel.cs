using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using MauiAppLaba.Model;
using MauiAppLaba.Utils;
using MauiAppLaba.View;
using MauiAppLaba.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLaba.ViewModel.LabTwoViewModel
{
    public partial class NoteViewModel:ViewModelBase, IQueryAttributable
    {
        private Note _note;

        public string Text
        {
            get => _note.Text; 
            set 
            {
                if (_note.Text != value)
                {
                    _note.Text = value;
                    OnPropertyChanged();
                }
            } 
        }
        public NoteViewModel(Note note)
        {
            _note = note;
        } 
        public NoteViewModel()
        {
            _note = new Note();
        }
        public DateTime Date => _note.Date;

        public string Identifier => _note.Filename;

        [RelayCommand]
        private async Task Save()
        {
            _note.Date = DateTime.Now;
            _note.Save();
            await Shell.Current.GoToAsync($"..?{Mode.Save.GetString()}={_note.Filename}");
        }

        [RelayCommand]
        private async Task Delete()
        {
            _note.Delete();
            await Shell.Current.GoToAsync($"..?{Mode.Delete.GetString()}={_note.Filename}");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _note = Note.Load(query["load"].ToString());
                RefreshProperties();
            }
        }
        public void Reload()
        {
            _note = Note.Load(_note.Filename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(Date));
        }
    }
}
