using System;
using System.ComponentModel;
using Gar.Client.Contracts.ViewModels;
using Gar.Root;
using Gar.Root.Contracts;
using Gar.Root.EventArguments;
using Gar.Root.Ui;

#pragma warning disable 0067

namespace Gar.Client.Design.ViewModels
{
    public class MainMenuViewModel : ViewModelRoot, IMainMenuViewModel
    {
        #region events

        public event EventHandler<SelectedValueEventArgs<string>> AccentUpdated;
        public event EventHandler<SelectedValueEventArgs<string>> ThemeUpdated;

        #endregion

        #region properties

        public SelectableValueList<string> Accents { get; } = new SelectableValueList<string>
                                                              {
                                                                  new Accent("Red"),
                                                                  new Accent("Green"),
                                                                  new Accent("Blue"),
                                                                  new Accent("Purple"),
                                                                  new Accent("Orange"),
                                                                  new Accent("Lime"),
                                                                  new Accent("Emerald"),
                                                                  new Accent("Teal"),
                                                                  new Accent("Cyan"),
                                                                  new Accent("Cobalt"),
                                                                  new Accent("Indigo"),
                                                                  new Accent("Violet"),
                                                                  new Accent("Pink"),
                                                                  new Accent("Magenta"),
                                                                  new Accent("Crimson"),
                                                                  new Accent("Amber"),
                                                                  new Accent("Yellow"),
                                                                  new Accent("Brown"),
                                                                  new Accent("Olive"),
                                                                  new Accent("Steel"),
                                                                  new Accent("Mauve"),
                                                                  new Accent("Taupe"),
                                                                  new Accent("Sienna")
                                                              };

        public SelectableValueList<string> Themes { get; } = new SelectableValueList<string> { new Theme("Light", "BaseLight"), new Theme("Dark", "BaseDark") };
        public override string ViewTitle => "Main Menu";

        #endregion

        #region methods

        public void SetAccent(string accent) {}
        public void SetTheme(string theme) {}

        #endregion

        #region nested types

        public class Theme : ISelectableValue<string>
        {
            #region constructors

            public Theme(string text, string value)
            {
                Text = text;
                Value = value;
            }

            #endregion

            #region events

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            #region properties

            public bool IsSelected { get; set; }
            public string Text { get; }
            public string Value { get; }

            #endregion
        }

        public class Accent : ISelectableValue<string>
        {
            #region constructors

            public Accent(string value)
            {
                Text = value;
                Value = value;
            }

            #endregion

            #region events

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            #region properties

            public bool IsSelected { get; set; }
            public string Text { get; }
            public string Value { get; }

            #endregion
        }

        #endregion
    }
}

#pragma warning restore 0067
