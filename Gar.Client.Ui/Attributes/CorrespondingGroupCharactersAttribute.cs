using System;

namespace Gar.Client.Ui.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CorrespondingGroupCharactersAttribute : Attribute
    {
        #region constructors

        public CorrespondingGroupCharactersAttribute(char start, char end)
        {
            Start = start;
            End = end;
        }

        #endregion

        #region properties

        public char End { get; }
        public char Start { get; }

        #endregion
    }
}
