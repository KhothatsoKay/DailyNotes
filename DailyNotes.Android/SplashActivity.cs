using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyNotes.Droid
{
    [Activity(Theme="@style/Theme.Splash",Label = "DailyNotes", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            System.Threading.Thread.Sleep(5000);
            StartActivity(typeof(MainActivity));
        }
    }
}