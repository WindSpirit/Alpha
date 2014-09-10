

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example
// http://slodge.blogspot.co.uk/2013/06/n26-fragments-n1-days-of-mvvmcross.html


using System;
using System.IO;
using System.Linq;
using Alpha.Droid.Contracts;
using Android.App;
using Android.OS;
using Android.Views;

using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Core.ViewModels;
using Alpha.Droid.Compatibility;
using Alpha.Droid.Fragments;
using Alpha.Droid.Specifics;
using Newtonsoft.Json;


namespace Alpha.Droid.Activities
{
	// Inheritance from MvxActionBarActivity is the key to implementing an ActionBar...
	[Activity(Theme = "@style/Theme.AppCompat.Light", Label = "My Alpha Droid", Icon = "@drawable/icon")]
	public class MainActivity : MvxActionBarActivity
	{
		// We use these fragment references for tab navigation, so we know what to show & hide
		public MvxFragment Fragment1 { get; private set; }
		public MvxFragment Fragment2 { get; private set; }

		protected override void OnCreate ( Bundle bundle )
		{
			base.OnCreate ( bundle );
			SetContentView ( Resource.Layout.Main );

			if ( SupportActionBar != null ) {
				SupportActionBar.SetDisplayHomeAsUpEnabled ( false );					// This is home and there is no up from here
				SupportActionBar.SetHomeButtonEnabled ( false );						// We do not need the home button click event
				SupportActionBar.NavigationMode = ( int ) ActionBarNavigationMode.Tabs;	// We want *tab* navigation
			}

			var nonConfigInstance = LastCustomNonConfigurationInstance;
			if (nonConfigInstance == null)
			{
				// Launching the main activity for the very first time
				Fragment1 = CreateActionBarTab<TabFragment1> ( "Tab 1", ( ( MainViewModel ) ViewModel ).TabFrag1 );		// Add our first tab
				Fragment2 = CreateActionBarTab<TabFragment2> ( "Tab 2", ( ( MainViewModel ) ViewModel ).TabFrag2 );		// Add our second tab

				var transaction = SupportFragmentManager.BeginTransaction ( );
				transaction.Add ( Resource.Id.fragment_container, Fragment1 );
				transaction.Add ( Resource.Id.fragment_container, Fragment2 );
				transaction.Hide ( Fragment2 );
				transaction.Commit ( );
			}
			else
			{
				// The FragmentManager is not going to forget about the tabs added to the ActionBar.
				// So we must reassociate the fragments being managed by the FragmentManager, to
				// the ActionBar tabs that we need to recreate.

				Fragment1 = ( MvxFragment ) SupportFragmentManager.Fragments.SingleOrDefault ( fragment => fragment is TabFragment1 );
				RestoreActionBarTab ( Fragment1, "Tab 1" );

				Fragment2 = ( MvxFragment ) SupportFragmentManager.Fragments.SingleOrDefault ( fragment => fragment is TabFragment2 );
				RestoreActionBarTab ( Fragment2, "Tab 2" );

				// Ensure the last used tab is our current tab.
				var storageBag = JsonConvert.DeserializeObject<MainActivityBag> ( ( nonConfigInstance as ActivityStorageBag ).StorageBag );
				SupportActionBar.SelectTab ( SupportActionBar.GetTabAt ( storageBag.ActiveTab ) );
			}
		}


		public override Java.Lang.Object OnRetainCustomNonConfigurationInstance ( )
		{
			base.OnRetainCustomNonConfigurationInstance ( );
			
			// This is going to persist in memory (as a Java.Lang.Object)
			var storageBag = new MainActivityBag() { ActiveTab = SupportActionBar.SelectedTab.Position };
			var json = JsonConvert.SerializeObject ( storageBag );
			return new ActivityStorageBag ( json );
		}


		protected void RestoreActionBarTab ( MvxFragment frag, string caption )
		{
			var tab = SupportActionBar.NewTab ( ).SetText ( caption );	// Create tab
			tab.SetTabListener ( new TabListenerImpl ( this ) );		// Setup tab listener
			SupportActionBar.AddTab ( tab );							// Add tab to ActionBar
		}

		protected MvxFragment CreateActionBarTab <T> ( string caption, MvxViewModel viewModel ) where T : MvxFragment, new ( )
		{
			var tab = SupportActionBar.NewTab().SetText(caption);		// Create tab
			var frag = new T()											// Create fragment for our tab
			{
				ViewModel = viewModel									// Associate container-fragment ViewModels
			};
			tab.SetTabListener ( new TabListenerImpl ( this ) );		// Setup tab listener
			SupportActionBar.AddTab ( tab );							// Add tab to ActionBar

			return frag;
		}

		public override bool OnCreateOptionsMenu ( IMenu menu )
		{
			MenuInflater.Inflate ( Resource.Menu.main_menu, menu );
			return true;
		}
	}
}

