

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example
// http://slodge.blogspot.co.uk/2013/06/n26-fragments-n1-days-of-mvvmcross.html


using Android.App;
using Android.OS;
using Android.Views;

using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Core.ViewModels;
using Alpha.Droid.Compatibility;
using Alpha.Droid.Fragments;
using Alpha.Droid.Specifics;


namespace Alpha.Droid.Activities {
	[Activity ( Theme = "@style/Theme.AppCompat.Light", Label = "My Alpha Droid", Icon = "@drawable/icon" )]
	public class MainActivity : MvxActionBarActivity
	{
		protected override void OnCreate ( Bundle bundle )
		{
			base.OnCreate ( bundle );
			SetContentView ( Resource.Layout.Main );
			if ( SupportActionBar != null ) {
				SupportActionBar.SetDisplayHomeAsUpEnabled ( false );										// This is home and there is no up from here
				SupportActionBar.SetHomeButtonEnabled ( false );											// We do not need the home button click event
				SupportActionBar.NavigationMode = (int)ActionBarNavigationMode.Tabs;						// We want *tab* navigation
				CreateActionBarTab<TabFragment1> ( "Tab 1", ( ( MainViewModel ) ViewModel ).TabFrag1 );		// Add our first tab
				CreateActionBarTab<TabFragment2> ( "Tab 2", ( ( MainViewModel ) ViewModel ).TabFrag2 );		// Add our second tab
			}
		}

		protected void CreateActionBarTab <T> ( string caption, MvxViewModel viewModel ) where T : MvxFragment, new ( )
		{
			var tab = SupportActionBar.NewTab().SetText(caption);		// Create tab
			var frag = new T()											// Create fragment for our tab
			{
				ViewModel = viewModel									// Associate container-fragment ViewModels
			};
			tab.SetTabListener ( new TabListenerImpl ( frag ) );		// Setup tab listener
			SupportActionBar.AddTab ( tab );							// Add tab to ActionBar
		}

		public override bool OnCreateOptionsMenu ( IMenu menu )
		{
			MenuInflater.Inflate ( Resource.Menu.main_menu, menu );
			return true;
		}

	}
}

