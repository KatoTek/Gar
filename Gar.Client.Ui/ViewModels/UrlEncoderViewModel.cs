﻿using System;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.ViewModels;
using static System.String;
using static System.Web.HttpUtility;

namespace Gar.Client.Ui.ViewModels
{
    public class UrlEncoderViewModel : InputOutputViewModel, IUrlEncoderViewModel
    {
        #region constructors

        public UrlEncoderViewModel() =>
            PropertyOf(() => Output)
                .OverridesWithoutBaseReference()
                .DependsOnProperty(() => Input);

        #endregion

        #region properties

        public override string Output =>
            GetValue(() => Output,
                     () =>
                     {
                         try
                         {
                             return IsNullOrWhiteSpace(Input)
                                        ? Empty
                                        : UrlEncode(Input);
                         }
                         catch (Exception exception)
                         {
                             return exception.ToText();
                         }
                     });

        public override string ViewTitle => "url";

        #endregion
    }
}
