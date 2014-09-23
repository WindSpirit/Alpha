

using System;
using System.Diagnostics;
using System.Globalization;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Core.Constituents;


namespace Alpha.Core.ViewModels
{
	public class TabFrag1ViewModel : AbstractViewModel
	{

		public TabFrag1ViewModel ( )
		{
			OnGotoPager = new MvxCommand ( GotoPager );
			OnRetrieveTitle = new MvxCommand( RetrieveTitle );
		}

		public IMvxCommand OnGotoPager { get; private set; }
		private void GotoPager ( ) { ShowViewModel<FragmentStatePagerViewModel> ( ); }

		public IMvxCommand OnRetrieveTitle { get; private set;  }
		private void RetrieveTitle()
		{
			var retriever = Mvx.IocConstruct<HtmlTitleRetriever>();

			string title = retriever.GetTitle(
				new Uri( "http://dotnetslackers.com/articles/designpatterns/InversionOfControlAndDependencyInjectionWithCastleWindsorContainerPart1.aspx")
			);

			title = string.Format(
				"{0}: {1}",
				retriever.FetchText.GetLocalizedText("key-value", new CultureInfo("en-CA")),
				title
			);

			Debug.WriteLine(title);
		}

		public IMvxCommand OnShowDialog { get; set; }

		private string _hello = "Tab (fragment) one.";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged ( ( ) => Hello ); }
		}
	}
}

