

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class FirstFragViewModel : AbstractViewModel
	{
		// Both Init methods will be called, because we passed an MvxBundle
		// and it had key-values "one" and "two" that could be coverted into
		// a string and int, respectively
		public void Init ( string one, int two )
		{
			var x = 1;	// Break-point
		}

		public void Init ( IMvxBundle test )
		{
			var x = 1;	// Break-point
		}

		private string _bigHello = "First Fragment!";
		public string TheBigHello {
			get { return _bigHello; }
			set { _bigHello = value; RaisePropertyChanged ( ( ) => TheBigHello ); }
		}
	}
}

