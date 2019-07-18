using System.Collections.Generic;
using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;
using INotify.Core;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IDelimitersViewModel : IViewModelRoot, ICsvInputProfile, IWhitespaceInputProfile
    {
        #region properties

        bool Ampersand { get; set; }
        bool Apostrophe { get; set; }
        bool Asterisk { get; set; }
        bool AtSign { get; set; }
        bool Backslash { get; set; }
        bool Caret { get; set; }
        bool CarriageReturn { get; set; }
        bool Colon { get; set; }
        bool Comma { get; set; }
        NotifyingList<char> Custom { get; }
        IEnumerable<char> Delimiters { get; }
        bool DollarSign { get; set; }
        bool EqualSign { get; set; }
        bool ExclamationPoint { get; set; }
        bool GraveAccent { get; set; }
        bool Hyphen { get; set; }
        bool PercentSign { get; set; }
        bool Period { get; set; }
        bool PlusSign { get; set; }
        bool PoundSign { get; set; }
        bool QuestionMark { get; set; }
        bool Quotation { get; set; }
        bool Semicolon { get; set; }
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
