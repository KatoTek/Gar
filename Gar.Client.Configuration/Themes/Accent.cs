using System.ComponentModel;
using System.Configuration;
using Gar.Root.Contracts;

namespace Gar.Client.Configuration.Themes
{
    public class Accent : ConfigurationElement, ISelectableValue<string>
    {
        #region fields

        bool _isSelected;

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;
                InvokePropertyChange(nameof(IsSelected));
            }
        }

        [ConfigurationProperty("text", IsRequired = true)]
        public string Text => (string)this["text"];

        [ConfigurationProperty("value", IsRequired = true, IsKey = true)]
        public string Value => (string)this["value"];

        #endregion

        #region methods

        void InvokePropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
