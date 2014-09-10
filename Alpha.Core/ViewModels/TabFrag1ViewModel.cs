

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class TabFrag1ViewModel : MvxViewModel
	{
		private string _hello = "Tab (fragment) one.";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

