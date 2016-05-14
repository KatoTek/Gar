using System;
using System.Linq;
using System.Reflection;
using Gar.Client.Contracts.ViewModels;
using Gar.Client.Ui.Attributes;
using Gar.Root.Ui;
using static System.Reflection.BindingFlags;
using static System.String;

namespace Gar.Client.Ui.ViewModels
{
    public class GroupersViewModel : ViewModelRoot, IGroupersViewModel
    {
        #region constructors

        public GroupersViewModel()
        {
            InitializeValue(true, () => Forced);

            PropertyOf(() => Standard)
                .DependsOnProperty(() => Conditional)
                .DependsOnProperty(() => Forced);

            PropertyOf(() => GroupEnd)
                .DependsOnProperty(() => Apostrophes)
                .DependsOnProperty(() => Braces)
                .DependsOnProperty(() => Brackets)
                .DependsOnProperty(() => LtGt)
                .DependsOnProperty(() => Parentheses)
                .DependsOnProperty(() => Quotes);

            PropertyOf(() => GroupStart)
                .DependsOnProperty(() => Apostrophes)
                .DependsOnProperty(() => Braces)
                .DependsOnProperty(() => Brackets)
                .DependsOnProperty(() => LtGt)
                .DependsOnProperty(() => Parentheses)
                .DependsOnProperty(() => Quotes);
        }

        #endregion

        #region properties

        [CorrespondingCharacter('\'')]
        [CorrespondingGroupCharacters('\'', '\'')]
        public bool Apostrophes
        {
            get { return GetValue(() => Apostrophes); }
            set { SetValue(Synchronize(value), () => Apostrophes); }
        }

        [CorrespondingGroupCharacters('{', '}')]
        public bool Braces
        {
            get { return GetValue(() => Braces); }
            set { SetValue(Synchronize(value), () => Braces); }
        }

        [CorrespondingGroupCharacters('[', ']')]
        public bool Brackets
        {
            get { return GetValue(() => Brackets); }
            set { SetValue(Synchronize(value), () => Brackets); }
        }

        public bool Conditional
        {
            get { return GetValue(() => Conditional); }
            set
            {
                if (!SetValue(value, () => Conditional) || !value)
                    return;

                Custom = false;
                Forced = false;
                CustomGroupStart = Empty;
                CustomGroupEnd = Empty;
            }
        }

        public bool Custom
        {
            get { return GetValue(() => Custom); }
            set
            {
                if (!SetValue(value, () => Custom) || !value)
                    return;

                Apostrophes = false;
                Braces = false;
                Conditional = false;
                Forced = false;
                LtGt = false;
                Parentheses = false;
                Quotes = false;
            }
        }

        public string CustomGroupEnd
        {
            get { return GetValue(() => CustomGroupEnd); }
            set { SetValue(value, () => CustomGroupEnd); }
        }

        public string CustomGroupStart
        {
            get { return GetValue(() => CustomGroupStart); }
            set { SetValue(value, () => CustomGroupStart); }
        }

        public bool Forced
        {
            get { return GetValue(() => Forced); }
            set
            {
                if (!SetValue(value, () => Forced) || !value)
                    return;

                Conditional = false;
                Custom = false;
                CustomGroupStart = Empty;
                CustomGroupEnd = Empty;
            }
        }

        public char? GroupEnd => GetValue(() => GroupEnd,
                                          () =>
                                          {
                                              var groupEnds = (from prop in GetType()
                                                                   .GetProperties(Public | Instance)
                                                                   .Where(p => p.PropertyType == typeof(bool))
                                                               where (bool)prop.GetValue(this)
                                                               select prop.GetCustomAttributes<CorrespondingGroupCharactersAttribute>()
                                                                          .FirstOrDefault()
                                                               into attr
                                                               where attr != null
                                                               select attr.End).ToArray();

                                              switch (groupEnds.Length)
                                              {
                                                  case 0:
                                                      return null;
                                                  case 1:
                                                      return groupEnds.Single();
                                                  default:
                                                      throw new IndexOutOfRangeException();
                                              }
                                          });

        public char? GroupStart => GetValue(() => GroupStart,
                                            () =>
                                            {
                                                var groupStarts = (from prop in GetType()
                                                                       .GetProperties(Public | Instance)
                                                                       .Where(p => p.PropertyType == typeof(bool))
                                                                   where (bool)prop.GetValue(this)
                                                                   select prop.GetCustomAttributes<CorrespondingGroupCharactersAttribute>()
                                                                              .FirstOrDefault()
                                                                   into correspondingGroupCharactersAttribute
                                                                   where correspondingGroupCharactersAttribute != null
                                                                   select correspondingGroupCharactersAttribute.Start).ToArray();

                                                switch (groupStarts.Length)
                                                {
                                                    case 0:
                                                        return null;
                                                    case 1:
                                                        return groupStarts.Single();
                                                    default:
                                                        throw new IndexOutOfRangeException();
                                                }
                                            });

        [CorrespondingGroupCharacters('<', '>')]
        public bool LtGt
        {
            get { return GetValue(() => LtGt); }
            set { SetValue(Synchronize(value), () => LtGt); }
        }

        [CorrespondingGroupCharacters('(', ')')]
        public bool Parentheses
        {
            get { return GetValue(() => Parentheses); }
            set { SetValue(Synchronize(value), () => Parentheses); }
        }

        [CorrespondingCharacter('"')]
        [CorrespondingGroupCharacters('\"', '\"')]
        public bool Quotes
        {
            get { return GetValue(() => Quotes); }
            set { SetValue(Synchronize(value), () => Quotes); }
        }

        public bool Standard => GetValue(() => Standard, () => Forced || Conditional);
        public override string ViewTitle => "Groupers";

        #endregion

        #region methods

        public void Deselect(char? @char)
        {
            if (!@char.HasValue)
                return;

            (from propertyInfo in GetType()
                 .GetProperties(Public | Instance)
                 .Where(propertyInfo => propertyInfo.PropertyType == typeof(bool))
             where (bool)propertyInfo.GetValue(this)
             select new
                    {
                        Property = propertyInfo,
                        CorrespondingCharacterAttribute = propertyInfo.GetCustomAttributes<CorrespondingCharacterAttribute>()
                                                                      .FirstOrDefault()
                    }
             into _
             where _.CorrespondingCharacterAttribute != null && _.CorrespondingCharacterAttribute.Character == @char
             select _.Property).FirstOrDefault()
                ?.SetValue(this, false);
        }

        public void SetCSharpOutputProfile()
        {
            Quotes = true;
            Forced = true;
        }

        public void SetCsvOutputProfile()
        {
            Quotes = true;
            Conditional = true;
        }

        public void SetJsonOutputProfile()
        {
            Apostrophes = true;
            Forced = true;
        }

        public void SetSqlOutputProfile()
        {
            Apostrophes = true;
            Forced = true;
        }

        bool Synchronize(bool reset)
        {
            if (!reset)
                return false;

            Apostrophes = false;
            Braces = false;
            Brackets = false;
            LtGt = false;
            Parentheses = false;
            Quotes = false;

            return true;
        }

        #endregion
    }
}
