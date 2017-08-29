using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DataClasses {

    public class SortableBindingList<T> : BindingList<T> {
        private ArrayList _sortedList;
        private bool _isSortedValue;

        public SortableBindingList() {
        }

        public SortableBindingList(IList<T> list) {
            foreach (object o in list) {
                this.Add((T)o);
            }
        }

        protected override bool SupportsSortingCore => true;


        protected override bool IsSortedCore => _isSortedValue;

        ListSortDirection _sortDirectionValue;
        PropertyDescriptor _sortPropertyValue;

        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction) {
            _sortedList = new ArrayList();

            var interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType) {
                var underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null) {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null) {
                _sortPropertyValue = prop;
                _sortDirectionValue = direction;

                IEnumerable<T> query = base.Items;
                query = direction == ListSortDirection.Ascending ? 
                    query.OrderBy(i => prop.GetValue(i)) : 
                    query.OrderByDescending(i => prop.GetValue(i));
                var newIndex = 0;
                foreach (object item in query) {
                    this.Items[newIndex] = (T)item;
                    newIndex++;
                }
                _isSortedValue = true;
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));

            }
            else {
                throw new NotSupportedException("Cannot sort by " + prop.Name +
                    "because type " + prop.PropertyType.ToString() +
                    " does not implement IComparable");
            }
        }

        protected override PropertyDescriptor SortPropertyCore => _sortPropertyValue;

        protected override ListSortDirection SortDirectionCore => _sortDirectionValue;
    }
}
