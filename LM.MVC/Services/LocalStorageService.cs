using Hanssens.Net;
using LM.MVC.Contracts;

namespace LM.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "LM.LEAVEMNGT"
            };

            _storage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string name, T value)
        {
            _storage.Store(name, value);
            _storage.Persist();
        }
    }
}
