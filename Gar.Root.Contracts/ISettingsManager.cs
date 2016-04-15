namespace Gar.Root.Contracts
{
    public interface ISettingsManager<T> where T : new()
    {
        #region methods

        T Get();
        void Initialize(T defaultSettings);
        void Set(T settings);

        #endregion
    }
}