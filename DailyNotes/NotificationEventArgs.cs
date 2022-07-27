using System;
using System.Collections.Generic;
using System.Text;
using DailyNotes.Models;

namespace DailyNotes
{
    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
