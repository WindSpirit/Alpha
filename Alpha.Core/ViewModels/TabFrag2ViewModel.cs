

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels 
{
	public class TabFrag2ViewModel : MvxViewModel
	{
		public TabFrag2ViewModel()
		{
			OnLoadFirstFrag = new MvxCommand ( LoadFirstFragment );
			OnLoadSecondFrag = new MvxCommand ( LoadSecondFragment );
			OnLoadThirdFrag = new MvxCommand ( LoadThirdFragment );
		}

		// public int CurrentFragment { get; set; }

		public IMvxCommand OnLoadFirstFrag { get; private set; }
		private void LoadFirstFragment ( ) {
			// Here we are using the custom-presenter to load our fragment...
			ShowViewModel<FirstFragViewModel> ( );
		}

		public IMvxCommand OnLoadSecondFrag { get; private set; }
		private void LoadSecondFragment ( ) {
			// Here we are using the custom-presenter to load our fragment...
			ShowViewModel<SecondFragViewModel> ( );
		}

		public IMvxCommand OnLoadThirdFrag { get; private set; }
		private void LoadThirdFragment ( ) {
			// Here we are using the custom-presenter to load our fragment...
			ShowViewModel<ThirdFragViewModel> ( );
		}

		private string _hello = "Tab (fragment) two.";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

