using System;

namespace Compose
{
	internal class WeakReferencingDynamicManager<TInterface, TOriginal> : DynamicManager<TInterface, TOriginal>
		where TInterface : class where TOriginal : TInterface
	{
		private readonly DynamicManagerContainer<TInterface, TOriginal> _container;

		public TInterface CurrentService { get; set; }
		public TInterface SnapshotService { get; set; }
		private WeakReference<TInterface> DynamicProxy { get; set; }

		public WeakReferencingDynamicManager(DynamicManagerContainer<TInterface, TOriginal> dynamicContainer, TransitionManagerContainer transitionContainer, TOriginal original)
		{
			_container = dynamicContainer;
			transitionContainer.Add(this);
			CurrentService = original;
			SnapshotService = original;
			_container.Add(this);
		}

		public void Register(TInterface dynamicProxy)
		{
			DynamicProxy = new WeakReference<TInterface>(dynamicProxy);
		}

		internal bool IsActive
		{
			get
			{
				TInterface dynamic = null;
				return DynamicProxy != null && DynamicProxy.TryGetTarget(out dynamic);
			}
		}

		public void Change(Func<TInterface> service)
		{
			_container.Change(service);
		}
	}
}
