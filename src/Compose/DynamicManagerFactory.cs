using System;
using System.Reflection;

namespace Compose
{
    internal static class DynamicManagerFactory
    {
		private static Type Exposer = typeof(DynamicManagerExposer<,>);

		internal static object ForFactory(TypeInfo dynamicManagerTypeInfo, object dynamicContainer, object transitionManager, object abstractFactory)
		{
			return Activator.CreateInstance(Exposer.MakeGenericType(dynamicManagerTypeInfo.GenericTypeArguments),
				dynamicContainer, transitionManager, abstractFactory
			);
		}

		private class DynamicManagerExposer<TInterface, TOriginal> : WeakReferencingDynamicManager<TInterface, TOriginal>
			where TInterface : class where TOriginal : TInterface
		{
			public DynamicManagerExposer(DynamicManagerContainer<TInterface, TOriginal> dynamicContainer, TransitionManagerContainer transitionContainer, AbstractFactory<TOriginal> factory)
				: base(dynamicContainer, transitionContainer, (TOriginal)factory.Create())
			{ }
        }
    }
}
