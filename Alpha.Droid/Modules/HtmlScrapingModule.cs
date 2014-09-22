

using Alpha.Droid.Fragments;
using Autofac;

using Alpha.Core.Constituents;
using Alpha.Core.Contracts;
using Alpha.Core.Contracts.Impl;
using Alpha.Droid.Contracts.Impl;


namespace Alpha.Droid.Modules
{
	public class HtmlScrapingModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// Usually, you're only interested in exposing the type via its interface:
			// cb.RegiserType<SomeType>().As.<IService>();
			// However, if you want BOTH services (not as common) you can say so:
			// cb.Registertype<sometype>().AsSelf().As<IService>();
			builder.RegisterType<HttpFileDownloader> ( ).As<IFileDownloader> ( );
			builder.RegisterType<StringParsingTitleScraper> ( ).As<ITitleScraper> ( );
			builder.RegisterType<FetchLocalizedText> ( ).As<ILocalizedText> ( );

			// Components (Constituent - Services), that rely on Dependency Injection, need to be a 
			// registered type, even though they do not rely on Interface Resolution.
			builder.RegisterType<HtmlTitleRetriever> ( ).PropertiesAutowired ( );

			builder.RegisterType<ArrayListFragment> ( );
			builder.RegisterType<FirstFrag> ( );
			builder.RegisterType<ImageFragment> ( );
			builder.RegisterType<SecondFrag> ( );
			builder.RegisterType<TabFragment1> ( );
			builder.RegisterType<TabFragment1ContextMenu> ( );
			builder.RegisterType<TabFragment2> ( );
			builder.RegisterType<ThirdFrag> ( );
		}
	}
}

