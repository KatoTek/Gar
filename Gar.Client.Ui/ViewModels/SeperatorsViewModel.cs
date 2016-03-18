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
            set { SetValue(Synchronize(value), () => Ampersand); }
        }

        [CorrespondingCharacter('\'')]
        public bool Apostrophe
        {
            get { return GetValue(() => Apostrophe); }
            set { SetValue(Synchronize(value), () => Apostrophe); }
        }

        [CorrespondingCharacter('*')]
        public bool Asterik
        {
            get { return GetValue(() => Asterik); }
            set { SetValue(Synchronize(value), () => Asterik); }
        }

        [CorrespondingCharacter('@')]
        public bool AtSign
        {
            get { return GetValue(() => AtSign); }
            set { SetValue(Synchronize(value), () => AtSign); }
        }

        [CorrespondingCharacter('\\')]
        public bool Backslash
        {
            get { return GetValue(() => Backslash); }
            set { SetValue(Synchronize(value), () => Backslash); }
        }

        [CorrespondingCharacter('^')]
        public bool Caret
        {
            get { return GetValue(() => Caret); }
            set { SetValue(Synchronize(value), () => Caret); }
        }

        [CorrespondingCharacter(':')]
        public bool Colon
        {
            get { return GetValue(() => Colon); }
            set { SetValue(Synchronize(value), () => Colon); }
        }

        [CorrespondingCharacter(',')]
        public bool Comma
        {
            get { return GetValue(() => Comma); }
            set { SetValue(Synchronize(value), () => Comma); }
        }

        public string Custom
        {
            get { return GetValue(() => Custom); }
            set { SetValue(Synchronize(value), () => Custom); }
        }

        [CorrespondingCharacter('$')]
        public bool DollarSign
        {
            get { return GetValue(() => DollarSign); }
            set { SetValue(Synchronize(value), () => DollarSign); }
        }

        [CorrespondingCharacter('=')]
        public bool EqualSign
        {
            get { return GetValue(() => EqualSign); }
            set { SetValue(Synchronize(value), () => EqualSign); }
        }

        [CorrespondingCharacter('!')]
        public bool ExclamationPoint
        {
            get { return GetValue(() => ExclamationPoint); }
            set { SetValue(Synchronize(value), () => ExclamationPoint); }
        }

        [CorrespondingCharacter('`')]
        public bool GraveAccent
        {
            get { return GetValue(() => GraveAccent); }
            set { SetValue(Synchronize(value), () => GraveAccent); }
        }

        [CorrespondingCharacter('-')]
        public bool Hyphen
        {
            get { return GetValue(() => Hyphen); }
            set { SetValue(Synchronize(value), () => Hyphen); }
        }

        [CorrespondingCharacter('%')]
        public bool PercentSign
        {
            get { return GetValue(() => PercentSign); }
            set { SetValue(Synchronize(value), () => PercentSign); }
        }

        [CorrespondingCharacter('.')]
        public bool Period
        {
            get { return GetValue(() => Period); }
            set { SetValue(Synchronize(value), () => Period); }
        }

        [CorrespondingCharacter('+')]
        public bool PlusSign
        {
            get { return GetValue(() => PlusSign); }
            set { SetValue(Synchronize(value), () => PlusSign); }
        }

        [CorrespondingCharacter('#')]
        public bool PoundSign
        {
            get { return GetValue(() => PoundSign); }
            set { SetValue(Synchronize(value), () => PoundSign); }
        }

        [CorrespondingCharacter('?')]
        public bool QuestionMark
        {
            get { return GetValue(() => QuestionMark); }
            set { SetValue(Synchronize(value), () => QuestionMark); }
        }

        [CorrespondingCharacter('"')]
        public bool Quotation
        {
            get { return GetValue(() => Quotation); }
            set { SetValue(Synchronize(value), () => Quotation); }
        }

        [CorrespondingCharacter(';')]
        public bool Semicolon
        {
            get { return GetValue(() => Semicolon); }
            set { SetValue(Synchronize(value), () => Semicolon); }
        }

        public string Seperator
        {
            get
            {
                return GetValue(() => Seperator,
                                () =>
                                {
                                    var seperators = (IsNullOrEmpty(Custom)
                                                          ? new string[0]
                                                          : new[] { Custom }).Union(from prop in GetType()
                                                                                        .GetProperties(Public | Instance)
                                                                                        .Where(p => p.PropertyType == typeof(bool))
                                                                                    where (bool)prop.GetValue(this)
                                                                                    select prop.GetCustomAttributes<CorrespondingCharacterAttribute>()
                                                                                               .FirstOrDefault()
                                                                                    into attr
                                                                                    where attr != null
                                                                                    select attr.Character.ToString())
                                                                             .ToArray();
                                    switch (seperators.Length)
                                    {
                                        case 0:
                                            return null;
                                        case 1:
                                            return seperators.Single();
                                        default:
                                            throw new IndexOutOfRangeException();
                                    }
                                });
            }
        }

        [CorrespondingCharacter('/')]
        public bool Slash
        {
            get { return GetValue(() => Slash); }
            set { SetValue(Synchronize(value), () => Slash); }
        }

        [CorrespondingCharacter(' ')]
        public bool Space
        {
            get { return GetValue(() => Space); }
            set { SetValue(Synchronize(value), () => Space); }
        }

        [CorrespondingCharacter('\t')]
        public bool Tab
        {
            get { return GetValue(() => Tab); }
            set { SetValue(Synchronize(value), () => Tab); }
        }

        [CorrespondingCharacter('~')]
        public bool Tilde
        {
            get { return GetValue(() => Tilde); }
            set { SetValue(Synchronize(value), () => Tilde); }
        }

        [CorrespondingCharacter('_')]
        public bool Underscore
        {
            get { return GetValue(() => Underscore); }
            set { SetValue(Synchronize(value), () => Underscore); }
        }

        public override string ViewTitle => "Seperators";

        #endregion

        #region methods

        public void Deselect(char? c)
        {
            if (!c.HasValue)
                return;

            if (Custom == c.ToString())
                Custom = null;

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
             where _.CorrespondingCharacterAttribute != null && _.CorrespondingCharacterAttribute.Character == c
             select _.Property).FirstOrDefault()
                ?.SetValue(this, false);
        }

        private string Synchronize(string value)
        {
            Synchronize(!IsNullOrEmpty(value));

            if (!IsNullOrEmpty(value))
                return null;

            var property = (from prop in GetType()
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
                            where _.CorrespondingCharacterAttribute != null && _.CorrespondingCharacterAttribute.Character.ToString() == value
                            select _.Property).FirstOrDefault();

            if (property == null)
                return value;

            property.SetValue(this, true);
            return null;
        }

        private bool Synchronize(bool reset)
        {
            if (!reset)
                return false;

            SetValue(false, () => Ampersand);
            SetValue(false, () => Apostrophe);
            SetValue(false, () => Asterik);
            SetValue(false, () => AtSign);
            SetValue(false, () => Backslash);
            SetValue(false, () => Caret);
            SetValue(false, () => Colon);
            SetValue(false, () => Comma);
            SetValue(null, () => Custom);
            SetValue(false, () => DollarSign);
            SetValue(false, () => EqualSign);
            SetValue(false, () => ExclamationPoint);
            SetValue(false, () => GraveAccent);
            SetValue(false, () => Hyphen);
            SetValue(false, () => PercentSign);
            SetValue(false, () => Period);
            SetValue(false, () => PlusSign);
            SetValue(false, () => PoundSign);
            SetValue(false, () => QuestionMark);
            SetValue(false, () => Quotation);
            SetValue(false, () => Semicolon);
            SetValue(false, () => Slash);
            SetValue(false, () => Space);
            SetValue(false, () => Tab);
            SetValue(false, () => Tilde);
            SetValue(false, () => Underscore);

            return true;
        }

        #endregion
    }
}
