using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppLaba.Model;
using MauiAppLaba.Utils;
using MauiAppLaba.View;
using MauiAppLaba.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLaba.ViewModel.LabTwoViewModel
{
    public partial class AllNotesPageViewModel : ViewModelBase, IQueryAttributable
    {
        public ObservableCollection<NoteViewModel>? AllNotes { get; private set; }

        public AllNotesPageViewModel()
        {
            var t = Mode.Load.GetString();
            AllNotes = Note.LoadAll().Select(n => new NoteViewModel(n)).ToObservableCollection();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(Mode.Delete.GetString()))
            {
                string noteId = query[Mode.Delete.GetString()].ToString();
                NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey(Mode.Save.GetString()))
            {
                string noteId = query[Mode.Save.GetString()].ToString();
                NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                {
                    matchedNote.Reload();
                    AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
                }
                // If note isn't found, it's new; add it.
                else
                    AllNotes.Insert(0, new NoteViewModel(Note.Load(noteId)));
            }
        }

        [RelayCommand]
        private async Task NewNotes()
        {
            await Shell.Current.GoToAsync(nameof(NotePageView));
        }

        [RelayCommand]
        private async Task SelectNoteAsync(NoteViewModel note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(NotePageView)}?{Mode.Load.GetString()}={note.Identifier}");
        }

    }
}
