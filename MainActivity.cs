using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Util;
namespace Utility
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Android.App.Fragment[] _fragments;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _fragments = new Android.App.Fragment[]
                             {
                             new WelcomeFragment(),
                             new ManageFragment(),
                             new ShipFragment()
                             };
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.activity_main);

            AddTabToActionBar(Resource.String.tab1);
            AddTabToActionBar(Resource.String.tab2);
            AddTabToActionBar(Resource.String.tab3);

        }
        void AddTabToActionBar(int labelResourceId)
        {
            var tab = ActionBar.NewTab()
                                         .SetText(labelResourceId);
            
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }
        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            var tab = (Android.App.ActionBar.Tab)sender;

            //  Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Android.App.Fragment frag = _fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}