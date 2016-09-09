using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class SeperatorsViewModel : ViewModelRoot, ISeperatorsViewModel
    {
        #region properties

        public bool Ampersand { get; set; }
        public bool Apostrophe { get; set; }
        public bool Asterik { get; set; }
        public bool AtSign { get; set; }
        public bool Backslash { get; set; }
        public bool Caret { get; set; }
        public bool Colon { get; set; }
        public bool Comma { get; set; } = true;
        public string Custom { get; set; }
        public bool DollarSign { get; set; }
        public bool EqualSign { get; set; }
        public bool ExclamationPoint { get; set; }
        public bool GraveAccent { get; set; }
        public bool Hyphen { get; set; }
        public bool InsertLineAfter { get; set; }
        public bool InsertLineBefore { get; set; }
        public bool PercentSign { get; set; }
        public bool Period { get; set; }
        public bool PlusSign { get; set; }
        public bool PoundSign { get; set; }
        public bool QuestionMark { get; set; }
        public bool Quotation { get; set; }
        public bool Semicolon { get; set; }
        public string Seperator { get; } = string.Empty;
        public bool Slash { get; set; }
        public bool Space { get; set; }
        public bool Tab { get; set; }
        public bool Tilde { get; set; }
        public bool Underscore { get; set; }
        public override string ViewTitle => "seperators";

        #endregion

        #region methods

        public void Deselect(char? c) {}
        public void SetCSharpOutputProfile() {}
        public void SetCsvOutputProfile() {}
        public void SetJsonOutputProfile() {}
        public void SetSqlOutputProfile() {}

        #endregion
    }
}
