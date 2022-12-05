namespace Provider;

public interface ISettingsProvider<T>
{
    T Read();
    void Updater(T item);
}