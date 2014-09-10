

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class FirstFragViewModel : MvxViewModel
	{
		private string _bigHello = "First Fragment!";
		public string TheBigHello {
			get { return _bigHello; }
			set { _bigHello = value; RaisePropertyChanged ( ( ) => TheBigHello ); }
		}
	}
}

