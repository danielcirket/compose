using System;
using Microsoft.Framework.DependencyInjection;

namespace Compose
{
	internal sealed class ServiceCollectionProvider<T> : Provider<T>
	{


		// because null collections suck bawls
		private static IServiceCollection EmptyServiceCollection = new ServiceCollection();

		public ServiceCollectionProvider(Func<IServiceProvider> primaryServiceProvider, Func<IServiceCollection, IServiceProvider> createTertiaryProvider, Func<IServiceCollection> primaryServices, Action<IServiceCollection> configureTertiaryServices)
		{
			if (primaryServiceProvider == null)
				throw new ArgumentNullException(nameof(primaryServiceProvider));
			if (createTertiaryProvider == null)
				throw new ArgumentNullException(nameof(createTertiaryProvider));
			if (primaryServices == null)
				throw new ArgumentNullException(nameof(primaryServices));
			if (configureTertiaryServices == null)
				throw new ArgumentNullException(nameof(configureTertiaryServices));
		}

		public T GetService()
		{
			//var primaryServices = MakePrimaryServicesAccessible();
			return default(T);
		}

		private IServiceCollection MakePrimaryServicesAccessible()
		{
			throw new NotImplementedException();
		}
	}
}
