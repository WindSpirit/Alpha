

using System.Dynamic;
using System.Globalization;
using Cirrious.CrossCore.IoC;


namespace Alpha.Core.Contracts.Impl {

	public class StringParsingTitleScraper : ITitleScraper
	{
		public string Scrape ( string fileContents )
		{
			string title = string.Empty;
			int openingTagIndex = fileContents.IndexOf("<title>", System.StringComparison.Ordinal);
			int closingTagIndex = fileContents.IndexOf("</title>", openingTagIndex, System.StringComparison.Ordinal);

			if (openingTagIndex != -1 && closingTagIndex != -1)
				title = fileContents
						.Substring( openingTagIndex, closingTagIndex - openingTagIndex )
						.Substring ( 7 );

			return title;
		}
	}
}

