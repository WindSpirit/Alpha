

using Android.OS;
using Android.Util;
using Android.Views;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

using ActionMode = Android.Support.V7.View.ActionMode;


namespace Alpha.Droid.Fragments
{
	public class TabFragment1ContextMenu : MvxFragment, ActionMode.ICallback, View.IOnLongClickListener
	{
		private ActionMode _actionMode;
		private View _view;

		public override View OnCreateView ( LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState )
		{
			var ignored = base.OnCreateView ( inflater, container, savedInstanceState );

			// Load the view with MvvmCross
			var root = this.BindingInflate(Resource.Layout.fragment_context_menu, null);

			// Get a reference to the view that we want to attach our context-sensitivity to
			_view = root.FindViewById(Resource.Id.long_press);

			// if (((int) Android.OS.Build.VERSION.SdkInt) >= 11) ;

			// Attach a long click listener to the view, as this indicates that the view wants context-sensitive options
			_view.SetOnLongClickListener( this );

			// Attach our depreciated context-menu to our view, as well
			RegisterForContextMenu ( _view );

			// Return our created view
			return root;
		}


		#region --[ Fragment Context-Menu ]--

		// See also http://developer.android.com/guide/topics/ui/menus.html#context-menu
		// This approach has been depreciated -- if you're developing for Android 3.0 (API level 11) or higher,
		// you should usually use the contextal action mode to present contextual actions, instead of the
		// floating context menu!
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

		#endregion


		#region --[ Context-Action-Bar (CAB), ActionMode.ICallback ]--

		public bool OnActionItemClicked(ActionMode mode, IMenuItem item)
		{
			return OnContextItemSelected(item);
		}

		public bool OnCreateActionMode(ActionMode mode, IMenu menu)
		{
			menu.Add ( Menu.None, 1, Menu.None, "Menu A" );
			menu.Add ( Menu.None, 2, Menu.None, "Menu B" );
			return true;
		}

		public void OnDestroyActionMode(ActionMode mode)
		{
			_actionMode = null;
		}

		public bool OnPrepareActionMode(ActionMode mode, IMenu menu)
		{
			return false;	// Return false if nothing is done
		}

		#endregion


		#region --[ Context indication event, View.IOnLongClickListener ]--


		public bool OnLongClick(View v)
		{
			if (_actionMode != null)
			{
				// Returning false, if the Context Action Bar (CAB), is already being displayed.
				// This will allow the depreciated context-menu to appear!
				return false;
			}
			else
			{
				// Start the CAB using ActionMode.ICallback interface defined on this class.
				// This will also prevent depreciated context-menu from being displayed.

				_actionMode = ( ( Android.Support.V7.App.ActionBarActivity ) Activity ).StartSupportActionMode ( this );

				_view.Selected = true;
				return true;
			}
		}

		#endregion
	}
}

