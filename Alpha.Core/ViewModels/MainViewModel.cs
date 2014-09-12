

namespace Alpha.Core.ViewModels
{
	public class MainViewModel : AbstractViewModel
    {
		// ViewModels need to maintain references to their child fragments
		// for the ActionBar Tabs

		private TabFrag1ViewModel _tabFrag1 = new TabFrag1ViewModel( );
		public TabFrag1ViewModel TabFrag1 {
			get { return _tabFrag1; }
			set { _tabFrag1 = value; RaisePropertyChanged ( ( ) => TabFrag1 ); }
		}

		private TabFrag2ViewModel _tabFrag2 = new TabFrag2ViewModel ( );
		public TabFrag2ViewModel TabFrag2 {
			get { return _tabFrag2; }
			set { _tabFrag2 = value; RaisePropertyChanged ( ( ) => TabFrag2 ); }
		}
    }
}

