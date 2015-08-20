namespace Compose
{
	public interface DynamicManager<TInterface, TOriginal> : DynamicRegister<TInterface>, TransitionManager<TInterface>
		where TInterface : class where TOriginal : TInterface
	{ }
}
