using System;

namespace Compose
{
    internal interface DynamicManagerContainer<TInterface, TOriginal> where TInterface : class where TOriginal : TInterface
    {
		void Add(WeakReferencingDynamicManager<TInterface, TOriginal> manager);
		void Change(Func<TInterface> service);
    }
}
