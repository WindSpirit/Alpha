

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class TabFrag1ViewModel : MvxViewModel
	{
		private string _hello = "Hello MvvmCross!  This is fragment one (1).";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

