using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IQualifiersViewModel : IViewModelRoot, ICsvInputProfile, IWhitespaceInputProfile
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
        char? Custom { get; set; }
        bool DollarSign { get; set; }
        bool EqualSign { get; set; }
        bool ExclamationPoint { get; set; }
        bool GraveAccent { get; set; }
        bool Hyphen { get; set; }
        bool PercentSign { get; set; }
        bool Period { get; set; }
        bool PlusSign { get; set; }
        bool PoundSign { get; set; }
        char? Qualifier { get; }
        bool QuestionMark { get; set; }
        bool Quotation { get; set; }
        bool Semicolon { get; set; }
        bool Slash { get; set; }
        bool Tilde { get; set; }
        bool Underscore { get; set; }

        #endregion

        #region methods

        void Deselect(char? c);

        #endregion
    }
}
