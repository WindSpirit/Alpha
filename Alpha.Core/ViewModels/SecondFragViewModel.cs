﻿

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class SecondFragViewModel : MvxViewModel
	{
		private string _myTextData = "Second Fragment!";
		public string MyTextData {
			get { return _myTextData; }
			set { _myTextData = value; RaisePropertyChanged ( ( ) => MyTextData ); }
		}
	}
}

