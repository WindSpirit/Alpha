

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alpha.Core.ViewModels
{
	public class LoginDialogViewModel : AbstractViewModel
	{
		private string _boundText = "Hello world!";
		public string BoundText {
			get { return _boundText; }
			set { _boundText = value; RaisePropertyChanged ( ( ) => BoundText ); }
		}
	}
}

