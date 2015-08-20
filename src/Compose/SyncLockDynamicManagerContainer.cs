using System;
using System.Collections.Generic;
using System.Reflection;

namespace Compose
{
	internal sealed class SyncLockDynamicManagerContainer<TInterface, TOriginal> : DynamicManagerContainer<TInterface, TOriginal>
		where TInterface : class where TOriginal : TInterface
	{
		private readonly List<WeakReferencingDynamicManager<TInterface, TOriginal>> _managers
			= new List<WeakReferencingDynamicManager<TInterface, TOriginal>>();
		private readonly object _sync = new object();

		private static TypeInfo Disposable = typeof(IDisposable).GetTypeInfo();

		public void Add(WeakReferencingDynamicManager<TInterface, TOriginal> manager)
		{
			lock (_sync)
			{
				_managers.Add(manager);
			}
		}

		private IEnumerable<WeakReferencingDynamicManager<TInterface, TOriginal>> GetActiveManagers()
		{
			var deadReferences = new List<WeakReferencingDynamicManager<TInterface, TOriginal>>(_managers.Count);

			lock (_sync)
			{
				foreach (var manager in _managers)
					if (manager.IsActive)
						yield return manager;
					else
						deadReferences.Add(manager);

				foreach (var deadReference in deadReferences)
					_managers.Remove(deadReference);
			}
		}

		public void Change(Func<TInterface> service)
		{
			foreach (var instance in GetActiveManagers())
				Change(instance, service());
		}

		private void Change(WeakReferencingDynamicManager<TInterface, TOriginal> manager, TInterface service)
		{
			if (manager.CurrentService != null && Disposable.IsAssignableFrom(manager.CurrentService.GetType().GetTypeInfo()))
				((IDisposable)manager.CurrentService).Dispose();
			manager.CurrentService = service;
		}
	}
}
