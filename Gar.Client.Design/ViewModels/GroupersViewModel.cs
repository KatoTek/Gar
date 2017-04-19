using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class GroupersViewModel : ViewModelRoot, IGroupersViewModel
    {
        #region properties

        public bool Apostrophes { get; set; }
        public bool Braces { get; set; }
        public bool Brackets { get; set; }
        public bool Conditional { get; set; }
        public bool Custom { get; set; }
        public string CustomGroupEnd { get; set; }
        public string CustomGroupStart { get; set; }
        public bool Forced { get; set; } = true;
        public char? GroupEnd { get; } = '\"';
        public char? GroupStart { get; } = '\"';
        public bool LtGt { get; set; }
        public bool Parentheses { get; set; }
        public bool Quotes { get; set; } = true;
        public bool Standard { get; } = true;
        public override string ViewTitle => "groupers";

        #endregion

        #region methods

        public void Deselect(char? c) { }
        public void SetCSharpOutputProfile() { }
        public void SetCsvOutputProfile() { }
        public void SetJsonOutputProfile() { }
        public void SetSqlOutputProfile() { }

        #endregion
    }
}
