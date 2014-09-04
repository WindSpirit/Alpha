

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example


using Cirrious.MvvmCross.Droid.Fragging.Fragments;

using ActionBar = Android.Support.V7.App.ActionBar;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;


namespace Alpha.Droid.Specifics
{
	public class TabListenerImpl : Java.Lang.Object, ActionBar.ITabListener
	{
		public MvxFragment Fragment;

		public TabListenerImpl(MvxFragment fragment)
		{
			Fragment = fragment;
		}

		public void OnTabReselected ( ActionBar.Tab tab, FragmentTransaction ft ) {
		}

		public void OnTabSelected ( ActionBar.Tab tab, FragmentTransaction ft ) {
			ft.Replace ( Resource.Id.fragment_container, Fragment );
		}

		public void OnTabUnselected ( ActionBar.Tab tab, FragmentTransaction ft ) {
			ft.Remove ( Fragment );
		}
	}
}

