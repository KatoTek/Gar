using System.Collections.Generic;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify.Core;

namespace Gar.Client.Design.ViewModels
{
    public class DelimitersViewModel : ViewModelRoot, IDelimitersViewModel
    {
        #region properties

        public bool Ampersand { get; set; }
        public bool Apostrophe { get; set; }
        public bool Asterik { get; set; }
        public bool AtSign { get; set; }
        public bool Backslash { get; set; }
        public bool Caret { get; set; }
        public bool CarriageReturn { get; set; } = true;
        public bool Colon { get; set; }
        public bool Comma { get; set; }
        public NotifyingList<char> Custom { get; } = new NotifyingList<char>();

        public IEnumerable<char> Delimiters { get; } = new[]
                                                       {
                                                           '\r',
                                                           '\n',
                                                           ' ',
                                                           '\t'
                                                       };

        public bool DollarSign { get; set; }
        public bool EqualSign { get; set; }
        public bool ExclamationPoint { get; set; }
        public bool GraveAccent { get; set; }
        public bool Hyphen { get; set; }
        public bool PercentSign { get; set; }
        public bool Period { get; set; }
        public bool PlusSign { get; set; }
        public bool PoundSign { get; set; }
        public bool QuestionMark { get; set; }
        public bool Quotation { get; set; }
        public bool Semicolon { get; set; }
        public bool Slash { get; set; }
        public bool Space { get; set; } = true;
        public bool Tab { get; set; } = true;
        public bool Tilde { get; set; }
        public bool Underscore { get; set; }
        public override string ViewTitle => "delimiters";

        #endregion

        #region methods

        public void Deselect(char? c) { }
        public void SetCsvInputProfile() { }
        public void SetWhitespaceInputProfile() { }

        #endregion
    }
}
