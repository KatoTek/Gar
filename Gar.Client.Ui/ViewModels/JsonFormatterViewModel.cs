using System;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.ViewModels;
using static System.String;
using static Newtonsoft.Json.Formatting;
using static Newtonsoft.Json.JsonConvert;

namespace Gar.Client.Ui.ViewModels
{
    public class JsonFormatterViewModel : InputOutputViewModel, IJsonFormatterViewModel
    {
        #region constructors

        public JsonFormatterViewModel() => PropertyOf(() => Output)
            .OverridesWithoutBaseReference()
            .DependsOnProperty(() => Input);

        #endregion

        #region properties

        public override string Output => GetValue(() => Output,
                                                  () =>
                                                  {
                                                      try
                                                      {
                                                          return IsNullOrWhiteSpace(Input)
                                                                     ? Empty
                                                                     : SerializeObject(DeserializeObject(Input), Indented);
                                                      }
                                                      catch (Exception exception)
                                                      {
                                                          return exception.ToText();
                                                      }
                                                  });

        public override string ViewTitle => "json";

        #endregion
    }
}
