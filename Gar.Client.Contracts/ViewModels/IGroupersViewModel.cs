using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IGroupersViewModel : IViewModelRoot, ISqlOutputProfile, ICSharpOutputProfile, IJsonOutputProfile, ICsvOutputProfile
    {
        #region properties

        bool Apostrophes { get; set; }
        bool Braces { get; set; }
        bool Brackets { get; set; }
        bool Conditional { get; set; }
        bool Custom { get; set; }
        string CustomGroupEnd { get; set; }
        string CustomGroupStart { get; set; }
        bool Forced { get; set; }
        char? GroupEnd { get; }
        char? GroupStart { get; }
        bool LtGt { get; set; }
        bool Parentheses { get; set; }
        bool Quotes { get; set; }
        bool Standard { get; }

        #endregion

        #region methods

        void Deselect(char? c);

        #endregion
    }
}
