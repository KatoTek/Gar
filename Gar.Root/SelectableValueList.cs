using System;
using System.Collections.Generic;
using System.Linq;
using Gar.Root.Contracts;
using INotify;

namespace Gar.Root
{
    public class SelectableValueList<T> : NotifyingCollection<ISelectableValue<T>>
    {
        #region constructors

        public SelectableValueList()
        {
            Initialize();
        }

        public SelectableValueList(int capacity)
            : base(capacity)
        {
            Initialize();
        }

        public SelectableValueList(IEnumerable<ISelectableValue<T>> collection)
            : base(collection)
        {
            Initialize();
            SetSelectedItem();
        }

        #endregion

        #region properties

        public override ISelectableValue<T> this[int index]
        {
            get { return base[index]; }
            set
            {
                if (base[index] == SelectedItem)
                    SelectedItem = null;

                SetSingleSelected(value, () => base[index] = value);
            }
        }

        public ISelectableValue<T> SelectedItem
        {
            get { return GetValue(() => SelectedItem); }
            private set { SetValue(value, () => SelectedItem); }
        }

        public string SelectedText => GetValue(() => SelectedText, () => SelectedItem?.Text);

        public T SelectedValue => GetValue(() => SelectedValue,
                                           () => SelectedItem != null
                                                     ? SelectedItem.Value
                                                     : default(T));

        #endregion

        #region methods

        public override void Add(ISelectableValue<T> item) => SetSingleSelected(item, () => base.Add(item));

        public override void AddRange(IEnumerable<ISelectableValue<T>> collection)
        {
            var selectableValues = collection as ISelectableValue<T>[] ?? collection.ToArray();
            SetSingleSelected(selectableValues, () => base.AddRange(selectableValues));
        }

        public override void Insert(int index, ISelectableValue<T> item) => SetSingleSelected(item, () => base.Insert(index, item));

        public override void InsertRange(int index, IEnumerable<ISelectableValue<T>> collection)
        {
            var selectableValues = collection as ISelectableValue<T>[] ?? collection.ToArray();
            SetSingleSelected(selectableValues, () => base.InsertRange(index, selectableValues));
        }

        public override bool Remove(ISelectableValue<T> item)
        {
            if (item == SelectedItem)
                SelectedItem = null;

            return base.Remove(item);
        }

        public override int RemoveAll(Predicate<ISelectableValue<T>> match)
        {
            if (FindAll(match)
                .Any(item => item == SelectedItem))
                SelectedItem = null;

            return base.RemoveAll(match);
        }

        public override void RemoveAt(int index)
        {
            if (this[index] == SelectedItem)
                SelectedItem = null;

            base.RemoveAt(index);
        }

        public void SetSelected(ISelectableValue<T> item) => this.Single(_ => _.Equals(item))
                                                                 .IsSelected = true;

        public void SetSelected(T value) => this.Single(_ => _.Value.Equals(value))
                                                .IsSelected = true;

        void Initialize()
        {
            PropertyOf(() => SelectedText)
                .DependsOnReferenceProperty(() => SelectedItem, (ISelectableValue<T> selectedItem) => selectedItem.Text);
            PropertyOf(() => SelectedValue)
                .DependsOnReferenceProperty(() => SelectedItem, (ISelectableValue<T> selectedItem) => selectedItem.Value);

            CollectionItemPropertyChangedFor((ISelectableValue<T> item) => item.IsSelected)
                .Execute(SetSelectedItem);
        }

        void SetSelectedItem()
        {
            var selectedItems = this.Where(item => item.IsSelected)
                                    .ToArray();

            if (selectedItems.Any())
            {
                switch (selectedItems.Length)
                {
                    case 1:
                        SelectedItem = selectedItems.Single();
                        break;
                    case 2:
                        var oldItem = selectedItems.Single(item => item == SelectedItem);
                        var newItem = selectedItems.Single(item => item != SelectedItem);
                        SelectedItem = newItem;
                        oldItem.IsSelected = false;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Too many items simultaneously selected.");
                }
            }
            else
                SelectedItem = null;
        }

        void SetSingleSelected(ISelectableValue<T> item, Action action = null)
        {
            if (item.IsSelected)
                ForEach(selectableItem => selectableItem.IsSelected = false);

            action?.Invoke();

            if (item.IsSelected)
                SelectedItem = item;
        }

        void SetSingleSelected(IEnumerable<ISelectableValue<T>> collection, Action action = null)
        {
            var selectedItem = collection.SingleOrDefault(item => item.IsSelected);
            if (selectedItem?.IsSelected ?? false)
                ForEach(selectableItem => selectableItem.IsSelected = false);

            action?.Invoke();

            if (selectedItem?.IsSelected ?? false)
                SelectedItem = selectedItem;
        }

        #endregion
    }
}
