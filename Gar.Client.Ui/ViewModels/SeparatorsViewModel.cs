using System;
using System.Linq;
using System.Reflection;
using Gar.Client.Contracts.ViewModels;
using Gar.Client.Ui.Attributes;
using Gar.Root.Ui;
using static System.Environment;
using static System.Reflection.BindingFlags;
using static System.String;

namespace Gar.Client.Ui.ViewModels
{
    public class SeparatorsViewModel : ViewModelRoot, ISeparatorsViewModel
    {
        #region constructors

        public SeparatorsViewModel()
        {
            InitializeValue(true, () => Comma);

            PropertyOf(() => Separator)
                .DependsOnProperty(() => Ampersand)
                .DependsOnProperty(() => Apostrophe)
                .DependsOnProperty(() => Asterisk)
                .DependsOnProperty(() => AtSign)
                .DependsOnProperty(() => Backslash)
                .DependsOnProperty(() => Caret)
                .DependsOnProperty(() => Colon)
                .DependsOnProperty(() => Comma)
                .DependsOnProperty(() => Custom)
                .DependsOnProperty(() => DollarSign)
                .DependsOnProperty(() => EqualSign)
                .DependsOnProperty(() => ExclamationPoint)
                .DependsOnProperty(() => GraveAccent)
                .DependsOnProperty(() => Hyphen)
                .DependsOnProperty(() => InsertLineAfter)
                .DependsOnProperty(() => InsertLineBefore)
                .DependsOnProperty(() => PercentSign)
                .DependsOnProperty(() => Period)
                .DependsOnProperty(() => PlusSign)
                .DependsOnProperty(() => PoundSign)
                .DependsOnProperty(() => QuestionMark)
                .DependsOnProperty(() => Quotation)
                .DependsOnProperty(() => Semicolon)
                .DependsOnProperty(() => Slash)
                .DependsOnProperty(() => Space)
                .DependsOnProperty(() => Tab)
                .DependsOnProperty(() => Tilde)
                .DependsOnProperty(() => Underscore);
        }

        #endregion

        #region properties

        [CorrespondingCharacter('&')]
        public bool Ampersand
        {
            get => GetValue(() => Ampersand);
            set => SetValue(SynchronizeSeparators(value), () => Ampersand);
        }

        [CorrespondingCharacter('\'')]
        public bool Apostrophe
        {
            get => GetValue(() => Apostrophe);
            set => SetValue(SynchronizeSeparators(value), () => Apostrophe);
        }

        [CorrespondingCharacter('*')]
        public bool Asterisk
        {
            get => GetValue(() => Asterisk);
            set => SetValue(SynchronizeSeparators(value), () => Asterisk);
        }

        [CorrespondingCharacter('@')]
        public bool AtSign
        {
            get => GetValue(() => AtSign);
            set => SetValue(SynchronizeSeparators(value), () => AtSign);
        }

        [CorrespondingCharacter('\\')]
        public bool Backslash
        {
            get => GetValue(() => Backslash);
            set => SetValue(SynchronizeSeparators(value), () => Backslash);
        }

        [CorrespondingCharacter('^')]
        public bool Caret
        {
            get => GetValue(() => Caret);
            set => SetValue(SynchronizeSeparators(value), () => Caret);
        }

        [CorrespondingCharacter(':')]
        public bool Colon
        {
            get => GetValue(() => Colon);
            set => SetValue(SynchronizeSeparators(value), () => Colon);
        }

        [CorrespondingCharacter(',')]
        public bool Comma
        {
            get => GetValue(() => Comma);
            set => SetValue(SynchronizeSeparators(value), () => Comma);
        }

        public string Custom
        {
            get => GetValue(() => Custom);
            set => SetValue(SynchronizeSeparators(value), () => Custom);
        }

        [CorrespondingCharacter('$')]
        public bool DollarSign
        {
            get => GetValue(() => DollarSign);
            set => SetValue(SynchronizeSeparators(value), () => DollarSign);
        }

        [CorrespondingCharacter('=')]
        public bool EqualSign
        {
            get => GetValue(() => EqualSign);
            set => SetValue(SynchronizeSeparators(value), () => EqualSign);
        }

        [CorrespondingCharacter('!')]
        public bool ExclamationPoint
        {
            get => GetValue(() => ExclamationPoint);
            set => SetValue(SynchronizeSeparators(value), () => ExclamationPoint);
        }

        [CorrespondingCharacter('`')]
        public bool GraveAccent
        {
            get => GetValue(() => GraveAccent);
            set => SetValue(SynchronizeSeparators(value), () => GraveAccent);
        }

        [CorrespondingCharacter('-')]
        public bool Hyphen
        {
            get => GetValue(() => Hyphen);
            set => SetValue(SynchronizeSeparators(value), () => Hyphen);
        }

        public bool InsertLineAfter
        {
            get => GetValue(() => InsertLineAfter);
            set => SetValue(SynchronizeLineInserts(value), () => InsertLineAfter);
        }

        public bool InsertLineBefore
        {
            get => GetValue(() => InsertLineBefore);
            set => SetValue(SynchronizeLineInserts(value), () => InsertLineBefore);
        }

        [CorrespondingCharacter('%')]
        public bool PercentSign
        {
            get => GetValue(() => PercentSign);
            set => SetValue(SynchronizeSeparators(value), () => PercentSign);
        }

        [CorrespondingCharacter('.')]
        public bool Period
        {
            get => GetValue(() => Period);
            set => SetValue(SynchronizeSeparators(value), () => Period);
        }

        [CorrespondingCharacter('+')]
        public bool PlusSign
        {
            get => GetValue(() => PlusSign);
            set => SetValue(SynchronizeSeparators(value), () => PlusSign);
        }

        [CorrespondingCharacter('#')]
        public bool PoundSign
        {
            get => GetValue(() => PoundSign);
            set => SetValue(SynchronizeSeparators(value), () => PoundSign);
        }

        [CorrespondingCharacter('?')]
        public bool QuestionMark
        {
            get => GetValue(() => QuestionMark);
            set => SetValue(SynchronizeSeparators(value), () => QuestionMark);
        }

        [CorrespondingCharacter('"')]
        public bool Quotation
        {
            get => GetValue(() => Quotation);
            set => SetValue(SynchronizeSeparators(value), () => Quotation);
        }

        [CorrespondingCharacter(';')]
        public bool Semicolon
        {
            get => GetValue(() => Semicolon);
            set => SetValue(SynchronizeSeparators(value), () => Semicolon);
        }

        public string Separator =>
            GetValue(() => Separator,
                     () =>
                     {
                         var separators = (IsNullOrEmpty(Custom)
                                               ? Array.Empty<string>()
                                               : new[]
                                                 {
                                                     Custom
                                                 }).Union(from propertyInfo in GetType()
                                                                               .GetProperties(Public | Instance)
                                                                               .Where(propertyInfo => propertyInfo.PropertyType == typeof(bool))
                                                          where (bool)propertyInfo.GetValue(this)
                                                          select propertyInfo.GetCustomAttributes<CorrespondingCharacterAttribute>()
                                                                             .FirstOrDefault()
                                                          into correspondingCharacterAttribute
                                                          where correspondingCharacterAttribute != null
                                                          select correspondingCharacterAttribute.Character.ToString())
                                                   .ToArray();

                         string separator;

                         switch (separators.Length)
                         {
                             case 0:
                                 separator = Empty;

                                 break;

                             case 1:
                                 separator = separators.Single();

                                 break;

                             default:
                                 throw new InvalidOperationException();
                         }

                         return InsertLineBefore ? $"{NewLine}{separator}" : InsertLineAfter ? $"{separator}{NewLine}" : separator;
                     });

        [CorrespondingCharacter('/')]
        public bool Slash
        {
            get => GetValue(() => Slash);
            set => SetValue(SynchronizeSeparators(value), () => Slash);
        }

        [CorrespondingCharacter(' ')]
        public bool Space
        {
            get => GetValue(() => Space);
            set => SetValue(SynchronizeSeparators(value), () => Space);
        }

        [CorrespondingCharacter('\t')]
        public bool Tab
        {
            get => GetValue(() => Tab);
            set => SetValue(SynchronizeSeparators(value), () => Tab);
        }

        [CorrespondingCharacter('~')]
        public bool Tilde
        {
            get => GetValue(() => Tilde);
            set => SetValue(SynchronizeSeparators(value), () => Tilde);
        }

        [CorrespondingCharacter('_')]
        public bool Underscore
        {
            get => GetValue(() => Underscore);
            set => SetValue(SynchronizeSeparators(value), () => Underscore);
        }

        public override string ViewTitle => "separators";

        #endregion

        #region methods

        public void Deselect(char? @char)
        {
            if (!@char.HasValue)
                return;

            if (Custom == @char.ToString())
                Custom = null;

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

        public void SetCSharpOutputProfile() => Comma = true;
        public void SetCsvOutputProfile() => Comma = true;
        public void SetJsonOutputProfile() => Comma = true;
        public void SetSqlOutputProfile() => Comma = true;

        bool SynchronizeLineInserts(bool reset)
        {
            if (!reset)
                return false;

            InsertLineAfter = false;
            InsertLineBefore = false;

            return true;
        }

        string SynchronizeSeparators(string value)
        {
            SynchronizeSeparators(!IsNullOrEmpty(value));

            if (!IsNullOrEmpty(value))
                return null;

            var property = (from propertyInfo in GetType()
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
                            where _.CorrespondingCharacterAttribute != null && _.CorrespondingCharacterAttribute.Character.ToString() == value
                            select _.Property).FirstOrDefault();

            if (property == null)
                return value;

            property.SetValue(this, true);

            return null;
        }

        bool SynchronizeSeparators(bool reset)
        {
            if (!reset)
                return false;

            Ampersand = false;
            Apostrophe = false;
            Asterisk = false;
            AtSign = false;
            Backslash = false;
            Caret = false;
            Colon = false;
            Comma = false;
            Custom = null;
            DollarSign = false;
            EqualSign = false;
            ExclamationPoint = false;
            GraveAccent = false;
            Hyphen = false;
            PercentSign = false;
            Period = false;
            PlusSign = false;
            PoundSign = false;
            QuestionMark = false;
            Quotation = false;
            Semicolon = false;
            Slash = false;
            Space = false;
            Tab = false;
            Tilde = false;
            Underscore = false;

            return true;
        }

        #endregion
    }
}
