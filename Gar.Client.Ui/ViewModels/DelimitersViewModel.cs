using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Gar.Client.Contracts.ViewModels;
using Gar.Client.Ui.Attributes;
using Gar.Root.Ui;
using INotify.Core;
using static System.Reflection.BindingFlags;

namespace Gar.Client.Ui.ViewModels
{
    public class DelimitersViewModel : ViewModelRoot, IDelimitersViewModel
    {
        #region constructors

        public DelimitersViewModel()
        {
            InitializeValue(new NotifyingList<char>(), () => Custom);
            InitializeValue(true, () => CarriageReturn);
            InitializeValue(true, () => Space);
            InitializeValue(true, () => Tab);

            PropertyOf(() => Delimiters)
                .DependsOnProperty(() => Ampersand)
                .DependsOnProperty(() => Apostrophe)
                .DependsOnProperty(() => Asterik)
                .DependsOnProperty(() => AtSign)
                .DependsOnProperty(() => Backslash)
                .DependsOnProperty(() => Caret)
                .DependsOnProperty(() => CarriageReturn)
                .DependsOnProperty(() => Colon)
                .DependsOnProperty(() => Comma)
                .DependsOnProperty(() => Custom)
                .DependsOnProperty(() => DollarSign)
                .DependsOnProperty(() => EqualSign)
                .DependsOnProperty(() => ExclamationPoint)
                .DependsOnProperty(() => GraveAccent)
                .DependsOnProperty(() => Hyphen)
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
            set => SetValue(value, () => Ampersand);
        }

        [CorrespondingCharacter('\'')]
        public bool Apostrophe
        {
            get => GetValue(() => Apostrophe);
            set => SetValue(value, () => Apostrophe);
        }

        [CorrespondingCharacter('*')]
        public bool Asterik
        {
            get => GetValue(() => Asterik);
            set => SetValue(value, () => Asterik);
        }

        [CorrespondingCharacter('@')]
        public bool AtSign
        {
            get => GetValue(() => AtSign);
            set => SetValue(value, () => AtSign);
        }

        [CorrespondingCharacter('\\')]
        public bool Backslash
        {
            get => GetValue(() => Backslash);
            set => SetValue(value, () => Backslash);
        }

        [CorrespondingCharacter('^')]
        public bool Caret
        {
            get => GetValue(() => Caret);
            set => SetValue(value, () => Caret);
        }

        public bool CarriageReturn
        {
            get => GetValue(() => CarriageReturn);
            set => SetValue(value, () => CarriageReturn);
        }

        [CorrespondingCharacter(':')]
        public bool Colon
        {
            get => GetValue(() => Colon);
            set => SetValue(value, () => Colon);
        }

        [CorrespondingCharacter(',')]
        public bool Comma
        {
            get => GetValue(() => Comma);
            set => SetValue(value, () => Comma);
        }

        public NotifyingList<char> Custom => GetValue(() => Custom);

        [SuppressMessage("ReSharper", "InvertIf")]
        public IEnumerable<char> Delimiters =>
            GetValue(() => Delimiters,
                     () =>
                     {
                         var delimiters = new List<char>(Custom);
                         if (CarriageReturn)
                         {
                             delimiters.Add('\r');
                             delimiters.Add('\n');
                         }

                         delimiters.AddRange(from prop in GetType()
                                                          .GetProperties(Public | Instance)
                                                          .Where(p => p.PropertyType == typeof(bool))
                                             where (bool)prop.GetValue(this)
                                             select prop.GetCustomAttributes<CorrespondingCharacterAttribute>()
                                                        .FirstOrDefault()
                                             into attr
                                             where attr != null
                                             select attr.Character);

                         return delimiters;
                     });

        [CorrespondingCharacter('$')]
        public bool DollarSign
        {
            get => GetValue(() => DollarSign);
            set => SetValue(value, () => DollarSign);
        }

        [CorrespondingCharacter('=')]
        public bool EqualSign
        {
            get => GetValue(() => EqualSign);
            set => SetValue(value, () => EqualSign);
        }

        [CorrespondingCharacter('!')]
        public bool ExclamationPoint
        {
            get => GetValue(() => ExclamationPoint);
            set => SetValue(value, () => ExclamationPoint);
        }

        [CorrespondingCharacter('`')]
        public bool GraveAccent
        {
            get => GetValue(() => GraveAccent);
            set => SetValue(value, () => GraveAccent);
        }

        [CorrespondingCharacter('-')]
        public bool Hyphen
        {
            get => GetValue(() => Hyphen);
            set => SetValue(value, () => Hyphen);
        }

        [CorrespondingCharacter('%')]
        public bool PercentSign
        {
            get => GetValue(() => PercentSign);
            set => SetValue(value, () => PercentSign);
        }

        [CorrespondingCharacter('.')]
        public bool Period
        {
            get => GetValue(() => Period);
            set => SetValue(value, () => Period);
        }

        [CorrespondingCharacter('+')]
        public bool PlusSign
        {
            get => GetValue(() => PlusSign);
            set => SetValue(value, () => PlusSign);
        }

        [CorrespondingCharacter('#')]
        public bool PoundSign
        {
            get => GetValue(() => PoundSign);
            set => SetValue(value, () => PoundSign);
        }

        [CorrespondingCharacter('?')]
        public bool QuestionMark
        {
            get => GetValue(() => QuestionMark);
            set => SetValue(value, () => QuestionMark);
        }

        [CorrespondingCharacter('"')]
        public bool Quotation
        {
            get => GetValue(() => Quotation);
            set => SetValue(value, () => Quotation);
        }

        [CorrespondingCharacter(';')]
        public bool Semicolon
        {
            get => GetValue(() => Semicolon);
            set => SetValue(value, () => Semicolon);
        }

        [CorrespondingCharacter('/')]
        public bool Slash
        {
            get => GetValue(() => Slash);
            set => SetValue(value, () => Slash);
        }

        [CorrespondingCharacter(' ')]
        public bool Space
        {
            get => GetValue(() => Space);
            set => SetValue(value, () => Space);
        }

        [CorrespondingCharacter('\t')]
        public bool Tab
        {
            get => GetValue(() => Tab);
            set => SetValue(value, () => Tab);
        }

        [CorrespondingCharacter('~')]
        public bool Tilde
        {
            get => GetValue(() => Tilde);
            set => SetValue(value, () => Tilde);
        }

        [CorrespondingCharacter('_')]
        public bool Underscore
        {
            get => GetValue(() => Underscore);
            set => SetValue(value, () => Underscore);
        }

        public override string ViewTitle => "delimiters";

        #endregion

        #region methods

        public void Deselect(char? @char)
        {
            if (!@char.HasValue)
                return;

            Custom?.RemoveAll(_ => _.Equals(@char));

            (from prop in GetType()
                          .GetProperties(Public | Instance)
                          .Where(p => p.PropertyType == typeof(bool))
             where (bool)prop.GetValue(this)
             select new
                    {
                        Property = prop,
                        CorrespondingCharacterAttribute = prop.GetCustomAttributes<CorrespondingCharacterAttribute>()
                                                              .FirstOrDefault()
                    }
             into _
             where _.CorrespondingCharacterAttribute != null && _.CorrespondingCharacterAttribute.Character == @char
             select _.Property).FirstOrDefault()
                               ?.SetValue(this, false);
        }

        public void SetCsvInputProfile()
        {
            CarriageReturn = false;
            Delimiters.ToList()
                      .ForEach(_ => Deselect(_));

            Comma = true;
        }

        public void SetWhitespaceInputProfile()
        {
            Delimiters.ToList()
                      .ForEach(_ => Deselect(_));

            CarriageReturn = true;
            Space = true;
            Tab = true;
        }

        #endregion
    }
}
