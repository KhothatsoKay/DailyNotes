
using DailyNotes.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DailyNotes
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntry), typeof(NoteEntry));


        }

    }
}
