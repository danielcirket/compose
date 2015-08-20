namespace Compose
{
    public interface Provider<T>
    {
		T GetService();
    }
}
