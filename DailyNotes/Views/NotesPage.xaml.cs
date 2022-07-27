using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyNotes.Models;
using DailyNotes.Views;

namespace DailyNotes.Views
{
    
    public partial class NotesPage : ContentPage
    {
        INotificationManager notificationManager;
        int notificationNumber = 0;
       

        public NotesPage()
        {
            InitializeComponent();
            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
             {
                 var evtData = (NotificationEventArgs)eventArgs;
                 ShowNotification(evtData.Title, evtData.Message);

             };

        }
        void OnSendClick(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Local Notification # {notificationNumber}";
            string message = $"You have now received{notificationNumber} notifications!";
            notificationManager.SendNotification(title, message);
        }
        void OnScheduleClick(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Local Notification # {notificationNumber}";
            string message = $"You have now received{notificationNumber} notifications!";
            notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"

                };
                
            
        });
            }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var notes = new List<Notes>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Notes
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)

                });
            }
            collectionView.ItemsSource = notes
                .OrderBy(d => d.Date )
                .ToList();
        }
           async void OnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteEntry));
        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Notes note = (Notes)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntry)}?{nameof(NoteEntry.ItemId)}={note.Filename}");
            }
            
        }
        }
    }
