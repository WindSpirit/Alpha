

using System.Globalization;


namespace Alpha.Core.Contracts.Impl
{
	public class FetchLocalizedText : ILocalizedText
	{
		public string GetLocalizedText(string key, CultureInfo ci)
		{
			return "Hello World";
		}
	}
}

