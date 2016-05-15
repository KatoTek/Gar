using System;

namespace Gar.Client.Contracts.Events
{
    public interface ICopyOutput
    {
        #region events

        event EventHandler<string> CopyOutput;

        #endregion
    }
}
