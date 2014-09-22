

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example
// http://slodge.blogspot.co.uk/2013/06/n26-fragments-n1-days-of-mvvmcross.html


using System.Linq;
using Alpha.Droid.Contracts;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;

using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Core.ViewModels;
using Alpha.Droid.Compatibility;
using Alpha.Droid.Fragments;
using Alpha.Droid.Specifics;
using Newtonsoft.Json;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;


namespace Alpha.Droid.Activities
{
	// Inheritance from MvxActionBarActivity is the key to implementing an ActionBar...
	[Activity(
		Label = "My Alpha Droid",
		Theme = "@style/Theme.AppCompat.Light",
		Icon = "@drawable/icon" ,
		MainLauncher = true
	)]
	public class MainActivity : MvxActionBarActivity
	{
		// We use these fragment references for tab navigation, so we know what to show & hide
		public MvxFragment Fragment1 { get; private set; }
		public MvxFragment Fragment2 { get; private set; }

		protected override void OnCreate ( Bundle bundle )
		{
			base.OnCreate ( bundle );
			SetContentView ( Resource.Layout.Main );

			if (Intent.Extras == null)
				NotifyUser();
			else if (! Intent.Extras.ContainsKey("key"))
				NotifyUser();
			else
				;	// This activity is being called by the notification ;-)

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
				// Activity is tranistioning states...

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
			
			// We did not need need a surogate class to persist the data, however,
			// we usually want to persist complex data structures rather than a simple integer.
			// This is a good example of persisting any arbitrary data.
			var storageBag = new MainActivityBag() { ActiveTab = SupportActionBar.SelectedTab.Position };
			var json = JsonConvert.SerializeObject ( storageBag );

			// Data returned from this method must be as a Java.Lang.Object
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


		public void NotifyUser()
		{
			//var nmgr = ( NotificationManager ) GetSystemService ( NotificationService );
			//var notify = new Notification(Resource.Drawable.Icon, "You have a notification");
			//// Need to learn more about Xamarin Intent creation
			//var intent = new Intent();
			//var pIntent = PendingIntent.GetActivity(this, 0, intent, 0);
			//notify.SetLatestEventInfo(this, "Event Header", "Today is your meeting", pIntent);
			//nmgr.Notify ( 0, notify );

			var valuesForActivity = new Bundle();
			valuesForActivity.PutString("key", "value");

			var resultIntent = new Intent(this, typeof (MainActivity));
			resultIntent.PutExtras(valuesForActivity);

			var stackBuilder = TaskStackBuilder.Create ( this );
			stackBuilder.AddParentStack( this );
			stackBuilder.AddNextIntent ( resultIntent );

			var resultPendingIntent = stackBuilder.GetPendingIntent(0, (int) PendingIntentFlags.UpdateCurrent);

			var builder = new NotificationCompat
				.Builder(this)
				.SetAutoCancel ( true )						// dismiss the notification from the notification area when the user clicks on it.
				.SetContentIntent ( resultPendingIntent )	// start up this activity when the user clicks the intent.
				.SetContentTitle ( "Event Title/Header" )
				.SetNumber(8)								// Lie, say there are 8 notifications ;-)
				.SetSmallIcon ( Resource.Drawable.Icon )
				.SetContentText("Today is your meeting!")
				.SetTicker("You have a notification");

			var nmgr = ( NotificationManager ) GetSystemService ( NotificationService );
			nmgr.Notify(0, builder.Build());
		}
	}
}

