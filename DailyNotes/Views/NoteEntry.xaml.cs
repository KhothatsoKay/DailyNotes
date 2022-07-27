using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyNotes.Models;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyNotes.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntry : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }
        public NoteEntry()
        {
            InitializeComponent();
            BindingContext = new Notes();
        }
        void LoadNote(string filename)
        {
            try
            {
                Notes note = new Notes
                {
                    Filename = filename,
                        Text = File.ReadAllText(filename),
                        Date = File.GetCreationTime(filename)

                };
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note");
            }
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Notes)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.Filename, note.Text);
            }

            await Shell.Current.GoToAsync("..");
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        { 
        var note = (Notes)BindingContext;
        if (File.Exists(note.Filename))
            {
            File.Delete(note.Filename);
            }
    await Shell.Current.GoToAsync("..");
}
    }
}