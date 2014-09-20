

using System;
using System.Globalization;
using Cirrious.CrossCore.IoC;

using Alpha.Core.Contracts;


namespace Alpha.Core.Constituents
{
	// Device independent component & service.

	// A component is a small unit of reusable code.
	// It should implement and expose just one service, and do it well.
	// In practical terms, a component is a class that implements a service (interface).
	// The interface is the contract of the service,
	// which creates an abstraction layer so you can replace the service implementation without effort.

	// see also http://dotnetslackers.com/articles/designpatterns/InversionOfControlAndDependencyInjectionWithCastleWindsorContainerPart1.aspx
	public class HtmlTitleRetriever
	{
		private readonly IFileDownloader downloader;
		private readonly ITitleScraper scraper;

		public HtmlTitleRetriever ( IFileDownloader downloader, ITitleScraper scraper ) {
			this.downloader = downloader;
			this.scraper = scraper;
		}

		public string GetTitle ( Uri file ) {
			string fileContents = downloader.Download ( file );
			return scraper.Scrape ( fileContents );
		}

		public ILocalizedText FetchText { get; set; }
	}
}

