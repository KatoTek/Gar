using System;
using System.IO;
using Gar.Root.Contracts;
using static System.Activator;
using static System.Environment;
using static System.IO.Directory;
using static System.IO.File;
using static System.Reflection.Assembly;
using static Newtonsoft.Json.JsonConvert;

namespace Gar.Root
{
    public class SettingsManager<T> : ISettingsManager<T> where T : new()
    {
        #region fields

        readonly string _directory;
        readonly string _file;
        T _cache;

        #endregion

        #region constructors

        public SettingsManager()
        {
            _directory = ExpandEnvironmentVariables($"%APPDATA%\\{GetEntryAssembly() .GetName() .Name}\\");
            _file = $"{typeof(T).FullName}.json";

            if (!File.Exists(Location))
            {
                OnInitialize += InitializeOnce;
                Set(CreateInstance<T>());
            }
            else
            {
                using (var streamReader = OpenText(Location))
                    _cache = DeserializeObject<T>(streamReader.ReadToEnd());
            }
        }

        #endregion

        #region events

        event InitializeEventHandler OnInitialize;

        #endregion

        #region properties

        string Location => $"{_directory}{_file}";

        #endregion

        #region methods

        public T Get() => _cache;
        public void Initialize(T defaultSettings) => OnInitialize?.Invoke(defaultSettings);

        public void Set(T settings)
        {
            OnInitialize -= InitializeOnce;

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var data = SerializeObject(settings);

            if (!Directory.Exists(_directory))
                CreateDirectory(_directory);

            if (File.Exists(Location))
                new FileInfo(Location).IsReadOnly = false;

            using (var fileStream = new FileStream(Location, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    try
                    {
                        streamWriter.Write(data);
                    }
                    finally
                    {
                        _cache = settings;
                    }
                }
            }
        }

        void InitializeOnce(T settings) => Set(settings);

        #endregion

        #region nested types

        delegate void InitializeEventHandler(T settings);

        #endregion
    }
}
