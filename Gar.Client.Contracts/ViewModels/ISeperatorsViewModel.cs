using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ISeperatorsViewModel : IViewModelRoot, ISqlOutputProfile
    {
        #region properties

        bool Ampersand { get; set; }
        bool Apostrophe { get; set; }
        bool Asterik { get; set; }
        bool AtSign { get; set; }
        bool Backslash { get; set; }
        bool Caret { get; set; }
        bool Colon { get; set; }
        bool Comma { get; set; }
        string Custom { get; set; }
        bool DollarSign { get; set; }
        bool EqualSign { get; set; }
        bool ExclamationPoint { get; set; }
        bool GraveAccent { get; set; }
        bool Hyphen { get; set; }
        bool InsertLineAfter { get; set; }
        bool InsertLineBefore { get; set; }
        bool PercentSign { get; set; }
        bool Period { get; set; }
        bool PlusSign { get; set; }
        bool PoundSign { get; set; }
        bool QuestionMark { get; set; }
        bool Quotation { get; set; }
        bool Semicolon { get; set; }
        string Seperator { get; }
        bool Slash { get; set; }
        bool Space { get; set; }
        bool Tab { get; set; }
        bool Tilde { get; set; }
        bool Underscore { get; set; }

        #endregion

        #region methods

        void Deselect(char? c);

        #endregion
    }
}
