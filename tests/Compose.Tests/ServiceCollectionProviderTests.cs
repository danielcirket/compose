using Microsoft.Framework.DependencyInjection;
using Moq;
using System;
using TestAttributes;
using Xunit;

namespace Compose.Tests
{
	public class ServiceCollectionProviderTests
	{
		private static Func<IServiceProvider> DefaultServiceProvider
		{
			get
			{
				return () => new Mock<IServiceProvider>().Object;
			}
		}

		private static Func<IServiceCollection, IServiceProvider> DefaultProviderFactory
		{
			get
			{
				return services => new Mock<IServiceProvider>().Object;
			}
		}

		private static Func<IServiceCollection> DefaultPrimaryServices
		{
			get
			{
				return () => new Mock<IServiceCollection>().Object;
			}
		}

		private static Action<IServiceCollection> DefaultTertiaryServicesConfiguration
		{
			get
			{
				return services => { };
			}
		}

		public class Constructor
		{
			[Unit]
			public static void WhenPrimaryServiceProviderIsNullThenThrowsException()
			{
				Action act = () => new ServiceCollectionProvider<object>(null, DefaultProviderFactory, DefaultPrimaryServices, DefaultTertiaryServicesConfiguration);
				Assert.Throws<ArgumentNullException>(act);
			}

			[Unit]
			public static void WhenServiceProviderFactoryIsNullThenThrowsException()
			{
				Action act = () => new ServiceCollectionProvider<object>(DefaultServiceProvider, null, DefaultPrimaryServices, DefaultTertiaryServicesConfiguration);
				Assert.Throws<ArgumentNullException>(act);
			}

			[Unit]
			public static void WhenPrimaryServicsIsNullThenThrowsException()
			{
				Action act = () => new ServiceCollectionProvider<object>(DefaultServiceProvider, DefaultProviderFactory, null, DefaultTertiaryServicesConfiguration);
				Assert.Throws<ArgumentNullException>(act);
			}

			[Unit]
			public static void WhenTertiaryServiceConfigurationIsNullThenThrowsException()
			{
				Action act = () => new ServiceCollectionProvider<object>(DefaultServiceProvider, DefaultProviderFactory, DefaultPrimaryServices, null);
				Assert.Throws<ArgumentNullException>(act);
			}
		}
	}
}
