

namespace Alpha.Core.ViewModels
{
	public class ThirdFragViewModel : AbstractViewModel
	{
		private string _dataFromThirdFrag = "Third Fragment!";
		public string DataFromThirdFragment {
			get { return _dataFromThirdFrag; }
			set { _dataFromThirdFrag = value; RaisePropertyChanged ( ( ) => DataFromThirdFragment ); }
		}
	}
}

