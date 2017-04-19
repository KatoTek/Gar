using System;

namespace Gar.Client.Ui.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CorrespondingCharacterAttribute : Attribute
    {
        #region constructors

        public CorrespondingCharacterAttribute(char character) => Character = character;

        #endregion

        #region properties

        public char Character { get; }

        #endregion
    }
}
