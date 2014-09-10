

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class ThirdFragViewModel : MvxViewModel
	{
		private string _dataFromThirdFrag = "Third Fragment!";
		public string DataFromThirdFragment {
			get { return _dataFromThirdFrag; }
			set { _dataFromThirdFrag = value; RaisePropertyChanged ( ( ) => DataFromThirdFragment ); }
		}
	}
}

