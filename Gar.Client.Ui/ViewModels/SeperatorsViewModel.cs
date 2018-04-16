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
    public class SeperatorsViewModel : ViewModelRoot, ISeperatorsViewModel
    {
        #region constructors

        public SeperatorsViewModel()
        {
            InitializeValue(true, () => Comma);

            PropertyOf(() => Seperator)
                .DependsOnProperty(() => Ampersand)
                .DependsOnProperty(() => Apostrophe)
                .DependsOnProperty(() => Asterik)
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
            set => SetValue(SynchronizeSeperators(value), () => Ampersand);
        }

        [CorrespondingCharacter('\'')]
        public bool Apostrophe
        {
            get => GetValue(() => Apostrophe);
            set => SetValue(SynchronizeSeperators(value), () => Apostrophe);
        }

        [CorrespondingCharacter('*')]
        public bool Asterik
        {
            get => GetValue(() => Asterik);
            set => SetValue(SynchronizeSeperators(value), () => Asterik);
        }

        [CorrespondingCharacter('@')]
        public bool AtSign
        {
            get => GetValue(() => AtSign);
            set => SetValue(SynchronizeSeperators(value), () => AtSign);
        }

        [CorrespondingCharacter('\\')]
        public bool Backslash
        {
            get => GetValue(() => Backslash);
            set => SetValue(SynchronizeSeperators(value), () => Backslash);
        }

        [CorrespondingCharacter('^')]
        public bool Caret
        {
            get => GetValue(() => Caret);
            set => SetValue(SynchronizeSeperators(value), () => Caret);
        }

        [CorrespondingCharacter(':')]
        public bool Colon
        {
            get => GetValue(() => Colon);
            set => SetValue(SynchronizeSeperators(value), () => Colon);
        }

        [CorrespondingCharacter(',')]
        public bool Comma
        {
            get => GetValue(() => Comma);
            set => SetValue(SynchronizeSeperators(value), () => Comma);
        }

        public string Custom
        {
            get => GetValue(() => Custom);
            set => SetValue(SynchronizeSeperators(value), () => Custom);
        }

        [CorrespondingCharacter('$')]
        public bool DollarSign
        {
            get => GetValue(() => DollarSign);
            set => SetValue(SynchronizeSeperators(value), () => DollarSign);
        }

        [CorrespondingCharacter('=')]
        public bool EqualSign
        {
            get => GetValue(() => EqualSign);
            set => SetValue(SynchronizeSeperators(value), () => EqualSign);
        }

        [CorrespondingCharacter('!')]
        public bool ExclamationPoint
        {
            get => GetValue(() => ExclamationPoint);
            set => SetValue(SynchronizeSeperators(value), () => ExclamationPoint);
        }

        [CorrespondingCharacter('`')]
        public bool GraveAccent
        {
            get => GetValue(() => GraveAccent);
            set => SetValue(SynchronizeSeperators(value), () => GraveAccent);
        }

        [CorrespondingCharacter('-')]
        public bool Hyphen
        {
            get => GetValue(() => Hyphen);
            set => SetValue(SynchronizeSeperators(value), () => Hyphen);
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
            set => SetValue(SynchronizeSeperators(value), () => PercentSign);
        }

        [CorrespondingCharacter('.')]
        public bool Period
        {
            get => GetValue(() => Period);
            set => SetValue(SynchronizeSeperators(value), () => Period);
        }

        [CorrespondingCharacter('+')]
        public bool PlusSign
        {
            get => GetValue(() => PlusSign);
            set => SetValue(SynchronizeSeperators(value), () => PlusSign);
        }

        [CorrespondingCharacter('#')]
        public bool PoundSign
        {
            get => GetValue(() => PoundSign);
            set => SetValue(SynchronizeSeperators(value), () => PoundSign);
        }

        [CorrespondingCharacter('?')]
        public bool QuestionMark
        {
            get => GetValue(() => QuestionMark);
            set => SetValue(SynchronizeSeperators(value), () => QuestionMark);
        }

        [CorrespondingCharacter('"')]
        public bool Quotation
        {
            get => GetValue(() => Quotation);
            set => SetValue(SynchronizeSeperators(value), () => Quotation);
        }

        [CorrespondingCharacter(';')]
        public bool Semicolon
        {
            get => GetValue(() => Semicolon);
            set => SetValue(SynchronizeSeperators(value), () => Semicolon);
        }

        public string Seperator =>
            GetValue(() => Seperator,
                     () =>
                     {
                         var seperators = (IsNullOrEmpty(Custom)
                                               ? new string[0]
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

                         string seperator;
                         switch (seperators.Length)
                         {
                             case 0:
                                 seperator = Empty;
                                 break;
                             case 1:
                                 seperator = seperators.Single();
                                 break;
                             default:
                                 throw new IndexOutOfRangeException();
                         }

                         return InsertLineBefore ? $"{NewLine}{seperator}" : InsertLineAfter ? $"{seperator}{NewLine}" : seperator;
                     });

        [CorrespondingCharacter('/')]
        public bool Slash
        {
            get => GetValue(() => Slash);
            set => SetValue(SynchronizeSeperators(value), () => Slash);
        }

        [CorrespondingCharacter(' ')]
        public bool Space
        {
            get => GetValue(() => Space);
            set => SetValue(SynchronizeSeperators(value), () => Space);
        }

        [CorrespondingCharacter('\t')]
        public bool Tab
        {
            get => GetValue(() => Tab);
            set => SetValue(SynchronizeSeperators(value), () => Tab);
        }

        [CorrespondingCharacter('~')]
        public bool Tilde
        {
            get => GetValue(() => Tilde);
            set => SetValue(SynchronizeSeperators(value), () => Tilde);
        }

        [CorrespondingCharacter('_')]
        public bool Underscore
        {
            get => GetValue(() => Underscore);
            set => SetValue(SynchronizeSeperators(value), () => Underscore);
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

        string SynchronizeSeperators(string value)
        {
            SynchronizeSeperators(!IsNullOrEmpty(value));

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

        bool SynchronizeSeperators(bool reset)
        {
            if (!reset)
                return false;

            Ampersand = false;
            Apostrophe = false;
            Asterik = false;
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
