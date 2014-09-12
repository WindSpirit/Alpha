

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels 
{
	public class TabFrag2ViewModel : AbstractViewModel
	{
		public TabFrag2ViewModel()
		{
			OnLoadFirstFrag = new MvxCommand ( LoadFirstFragment );
			OnLoadSecondFrag = new MvxCommand ( LoadSecondFragment );
			OnLoadThirdFrag = new MvxCommand ( LoadThirdFragment );
		}

		public IMvxCommand OnLoadFirstFrag { get; private set; }
		private void LoadFirstFragment ( ) { ShowViewModel<FirstFragViewModel> ( ); }

		public IMvxCommand OnLoadSecondFrag { get; private set; }
		private void LoadSecondFragment ( ) { ShowViewModel<SecondFragViewModel> ( ); }

		public IMvxCommand OnLoadThirdFrag { get; private set; }
		private void LoadThirdFragment ( ) { ShowViewModel<ThirdFragViewModel> ( ); }

		private string _hello = "Tab (fragment) two.";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

