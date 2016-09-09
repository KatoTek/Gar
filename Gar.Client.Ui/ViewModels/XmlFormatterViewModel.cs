using System;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.ViewModels;
using static System.String;
using static System.Xml.Linq.XDocument;

namespace Gar.Client.Ui.ViewModels
{
    public class XmlFormatterViewModel : InputOutputViewModel, IXmlFormatterViewModel
    {
        #region constructors

        public XmlFormatterViewModel()
        {
            PropertyOf(() => Output)
                .OverridesWithoutBaseReference()
                .DependsOnProperty(() => Input);
        }

        #endregion

        #region properties

        public override string Output
        {
            get
            {
                return GetValue(() => Output,
                                () =>
                                {
                                    try
                                    {
                                        return IsNullOrWhiteSpace(Input)
                                                   ? Empty
                                                   : Parse(Input)
                                                         .ToString();
                                    }
                                    catch (Exception exception)
                                    {
                                        return exception.ToText();
                                    }
                                });
            }
        }

        public override string ViewTitle => "xml";

        #endregion
    }
}
