

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class TabFrag1ViewModel : AbstractViewModel
	{

		public TabFrag1ViewModel ( )
		{
			OnGotoPager = new MvxCommand ( GotoPager );
		}

		public IMvxCommand OnGotoPager { get; private set; }
		private void GotoPager ( ) { ShowViewModel<FragmentStatePagerViewModel> ( ); }

		private string _hello = "Tab (fragment) one.";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

