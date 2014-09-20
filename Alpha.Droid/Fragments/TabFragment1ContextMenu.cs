

using Android.OS;
using Android.Util;
using Android.Views;

using Cirrious.MvvmCross.Droid.Fragging.Fragments;


namespace Alpha.Droid.Fragments
{
	public class TabFragment1ContextMenu : MvxFragment
	{
		public override View OnCreateView ( LayoutInflater inflater, ViewGroup container, Bundle p2 )
		{
			var root = inflater.Inflate ( Resource.Layout.fragment_context_menu, container, false );
			RegisterForContextMenu ( root.FindViewById ( Resource.Id.long_press ) );
			return root;
		}

		public override void OnCreateContextMenu ( IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo )
		{
			base.OnCreateContextMenu ( menu, v, menuInfo );

			menu.Add ( Menu.None, 1, Menu.None, "Menu A" );
			menu.Add ( Menu.None, 2, Menu.None, "Menu B" );
		}

		public override bool OnContextItemSelected ( IMenuItem item )
		{
			switch ( item.ItemId )
			{
				case 1: Log.Info ( "ContextMenu", "Item 1a was chosen" ); return true;
				case 2: Log.Info ( "ContextMenu", "Item 1b was chosen" ); return true;
			}
			return base.OnContextItemSelected ( item );
		}
	}
}

