/*
 * ActionBar Tab Fragment: is demonstrated here.
 * 
 * Fragment Menu Support: is demonstrated through the implementation of an option menu.
 * 
 * Clicking on the button will result in navigation to the Fragment Pager (Fragment State Pager),
 * as implemented in FragmentStatePagerViewModel.cs & FragmentStatePagerActivity.cs
 * 
 */



// http://arvid-g.de/12/android-4-actionbar-with-tabs-example


using Android.OS;
using Android.Support.V4.View;
using Android.Views;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

using Alpha.Core.ViewModels;


namespace Alpha.Droid.Fragments
{
	public class TabFragment1 : MvxFragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Fragment Menu Support: Indicate fragment updates the option menu On Create
			HasOptionsMenu = true;

			var content = new TabFragment1ContextMenu();
			FragmentManager.BeginTransaction ( ).Add ( /* Android.Resource.Id.Content */ Resource.Id.tab1ContextMenu, content ).Commit ( );
		}

		public override Android.Views.View OnCreateView ( Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState )
		{
			// ActionBar Tab Fragment: Retain (persist) this fragment, as the ActionBar tab is referencing it
			RetainInstance = true;

			// Call the base method
			base.OnCreateView ( inflater, container, savedInstanceState );

			// ActionBar Tab Fragment: MvvmCross binding, during the Inflate process
			return this.BindingInflate ( Resource.Layout.TabFrag1, null );
		}


		public override void OnCreateOptionsMenu ( Android.Views.IMenu menu, Android.Views.MenuInflater inflater )
		{
			// Fragment Menu Support: Call the base method
			base.OnCreateOptionsMenu ( menu, inflater );

			// Fragment Menu Support: Create menu item(s), as required, and add them to ActionBar option menu
			IMenuItem item = menu.Add(0, 3, 0, "Frag Menu Item");
			MenuCompat.SetShowAsAction(item, MenuItemCompat.ShowAsActionIfRoom);
		}

		public override bool OnOptionsItemSelected ( IMenuItem item )
		{
			// Fragment Menu Support: Perform item selection as required
			switch ( item.ItemId )
			{
				case 3: return true;
				default: return base.OnOptionsItemSelected ( item );
			}
		}
	}
}

