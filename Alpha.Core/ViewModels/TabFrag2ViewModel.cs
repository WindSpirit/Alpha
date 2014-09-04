

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels 
{
	public class TabFrag2ViewModel : MvxViewModel
	{
		private string _hello = "Hello MvvmCross!  This is fragment two (2).";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

