

namespace Alpha.Core.ViewModels
{
	public class SecondFragViewModel : AbstractViewModel
	{
		private string _myTextData = "Second Fragment!";
		public string MyTextData {
			get { return _myTextData; }
			set { _myTextData = value; RaisePropertyChanged ( ( ) => MyTextData ); }
		}
	}
}

