

namespace Alpha.Core.Contracts
{
	// Service - Scrape document title
	public interface ITitleScraper
	{
		string Scrape(string fileContents);
	}
}

