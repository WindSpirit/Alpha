

namespace Alpha.Core.ViewModels
{
	public class ImageViewModel : AbstractViewModel
	{
		private string _caption;
		public string Caption {
			get { return _caption; }
			set { SetProperty ( ref _caption, value ); }
		}
	}
}

