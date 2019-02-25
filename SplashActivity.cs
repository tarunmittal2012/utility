using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Utility
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    class SplashActivity : AppCompatActivity
    {
        public override void OnBackPressed()
        {
       //     base.OnBackPressed();
        }

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            Task startupWork = new Task(() => { SimulateStartUp(); });

            base.OnResume();
        }
        async void SimulateStartUp()
        {
            await Task.Delay(8000); // Simulate a bit of startup work.

            StartActivity(new Intent(ApplicationContext, typeof(MainActivity)));
        }
    }
}