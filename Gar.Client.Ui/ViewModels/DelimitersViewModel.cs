using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Gar.Client.Contracts.ViewModels;
using Gar.Client.Ui.Attributes;
using Gar.Root.Ui;
using INotify;
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
            get { return GetValue(() => Ampersand); }
            set { SetValue(value, () => Ampersand); }
        }

        [CorrespondingCharacter('\'')]
        public bool Apostrophe
        {
            get { return GetValue(() => Apostrophe); }
            set { SetValue(value, () => Apostrophe); }
        }

        [CorrespondingCharacter('*')]
        public bool Asterik
        {
            get { return GetValue(() => Asterik); }
            set { SetValue(value, () => Asterik); }
        }

        [CorrespondingCharacter('@')]
        public bool AtSign
        {
            get { return GetValue(() => AtSign); }
            set { SetValue(value, () => AtSign); }
        }

        [CorrespondingCharacter('\\')]
        public bool Backslash
        {
            get { return GetValue(() => Backslash); }
            set { SetValue(value, () => Backslash); }
        }

        [CorrespondingCharacter('^')]
        public bool Caret
        {
            get { return GetValue(() => Caret); }
            set { SetValue(value, () => Caret); }
        }

        public bool CarriageReturn
        {
            get { return GetValue(() => CarriageReturn); }
            set { SetValue(value, () => CarriageReturn); }
        }

        [CorrespondingCharacter(':')]
        public bool Colon
        {
            get { return GetValue(() => Colon); }
            set { SetValue(value, () => Colon); }
        }

        [CorrespondingCharacter(',')]
        public bool Comma
        {
            get { return GetValue(() => Comma); }
            set { SetValue(value, () => Comma); }
        }

        public NotifyingList<char> Custom
        {
            get { return GetValue(() => Custom); }
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        public IEnumerable<char> Delimiters => GetValue(() => Delimiters,
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
            get { return GetValue(() => DollarSign); }
            set { SetValue(value, () => DollarSign); }
        }

        [CorrespondingCharacter('=')]
        public bool EqualSign
        {
            get { return GetValue(() => EqualSign); }
            set { SetValue(value, () => EqualSign); }
        }

        [CorrespondingCharacter('!')]
        public bool ExclamationPoint
        {
            get { return GetValue(() => ExclamationPoint); }
            set { SetValue(value, () => ExclamationPoint); }
        }

        [CorrespondingCharacter('`')]
        public bool GraveAccent
        {
            get { return GetValue(() => GraveAccent); }
            set { SetValue(value, () => GraveAccent); }
        }

        [CorrespondingCharacter('-')]
        public bool Hyphen
        {
            get { return GetValue(() => Hyphen); }
            set { SetValue(value, () => Hyphen); }
        }

        [CorrespondingCharacter('%')]
        public bool PercentSign
        {
            get { return GetValue(() => PercentSign); }
            set { SetValue(value, () => PercentSign); }
        }

        [CorrespondingCharacter('.')]
        public bool Period
        {
            get { return GetValue(() => Period); }
            set { SetValue(value, () => Period); }
        }

        [CorrespondingCharacter('+')]
        public bool PlusSign
        {
            get { return GetValue(() => PlusSign); }
            set { SetValue(value, () => PlusSign); }
        }

        [CorrespondingCharacter('#')]
        public bool PoundSign
        {
            get { return GetValue(() => PoundSign); }
            set { SetValue(value, () => PoundSign); }
        }

        [CorrespondingCharacter('?')]
        public bool QuestionMark
        {
            get { return GetValue(() => QuestionMark); }
            set { SetValue(value, () => QuestionMark); }
        }

        [CorrespondingCharacter('"')]
        public bool Quotation
        {
            get { return GetValue(() => Quotation); }
            set { SetValue(value, () => Quotation); }
        }

        [CorrespondingCharacter(';')]
        public bool Semicolon
        {
            get { return GetValue(() => Semicolon); }
            set { SetValue(value, () => Semicolon); }
        }

        [CorrespondingCharacter('/')]
        public bool Slash
        {
            get { return GetValue(() => Slash); }
            set { SetValue(value, () => Slash); }
        }

        [CorrespondingCharacter(' ')]
        public bool Space
        {
            get { return GetValue(() => Space); }
            set { SetValue(value, () => Space); }
        }

        [CorrespondingCharacter('\t')]
        public bool Tab
        {
            get { return GetValue(() => Tab); }
            set { SetValue(value, () => Tab); }
        }

        [CorrespondingCharacter('~')]
        public bool Tilde
        {
            get { return GetValue(() => Tilde); }
            set { SetValue(value, () => Tilde); }
        }

        [CorrespondingCharacter('_')]
        public bool Underscore
        {
            get { return GetValue(() => Underscore); }
            set { SetValue(value, () => Underscore); }
        }

        public override string ViewTitle => "Delimiters";

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

        #endregion
    }
}
