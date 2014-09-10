

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example


using ActionBar = Android.Support.V7.App.ActionBar;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

using Alpha.Droid.Activities;


namespace Alpha.Droid.Specifics
{
	public class TabListenerImpl : Java.Lang.Object, ActionBar.ITabListener
	{
		public MainActivity Owner;

		public TabListenerImpl(  MainActivity owner)
		{
			Owner = owner;
		}

		public void OnTabReselected ( ActionBar.Tab tab, FragmentTransaction ft ) {
		}

		public void OnTabSelected ( ActionBar.Tab tab, FragmentTransaction ft ) {
			// Replace will force a new fragment instance to be created, causing lots of tombstoning issues
			// ft.Replace ( Resource.Id.fragment_container, Fragment );

			switch (tab.Position)
			{
				case 0: if ( Owner.Fragment1 != null ) ft.Show(Owner.Fragment1); break;
				case 1: if ( Owner.Fragment2 != null ) ft.Show(Owner.Fragment2); break;
			}
		}

		public void OnTabUnselected ( ActionBar.Tab tab, FragmentTransaction ft ) {
			// Remove will force a new fragment instance to be created, causing lots of tombstoning issues
			// ft.Remove ( Fragment );

			switch ( tab.Position ) {
				case 0: ft.Hide(Owner.Fragment1); break;
				case 1: ft.Hide(Owner.Fragment2); break;
			}
		}
	}
}

