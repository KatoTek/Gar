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
        public bool Forced { get; set; } = true;
        public char? GroupEnd { get; } = '\"';
        public char? GroupStart { get; } = '\"';
        public bool LtGt { get; set; }
        public bool Parentheses { get; set; }
        public bool Quotes { get; set; } = true;
        public override string ViewTitle => "Groupers";

        #endregion

        #region methods

        public void Deselect(char? c) {}

        #endregion
    }
}
