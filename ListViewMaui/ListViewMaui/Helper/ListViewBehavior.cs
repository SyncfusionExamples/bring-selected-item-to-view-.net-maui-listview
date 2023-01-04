using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    #region ListViewBehavior
    public class ListViewBehavior : Behavior<SfListView>
    {
        #region Fields
        private SfListView ListView;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(SfListView bindable)
        {
            ListView = bindable;
            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "ContactName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as ListViewContactInfo);
                    return item.ContactName[0].ToString();
                },
            });

            ListView.PropertyChanged += ListView_PropertyChanged;
            base.OnAttachedTo(bindable);
        }

        private void ListView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                ListView.Dispatcher.Dispatch(async () =>
                {
                    await Task.Delay(100);
                    if (this.ListView.DataSource.DisplayItems.Count > 0)
                    {
                        var selectedItemIndex = ListView.DataSource.DisplayItems.IndexOf(ListView.SelectedItem);
                        selectedItemIndex += (ListView.HeaderTemplate != null && !ListView.IsStickyHeader && !ListView.IsStickyGroupHeader) ? 1 : 0;
                        (ListView.ItemsLayout as LinearLayout).ScrollToRowIndex(selectedItemIndex);
                    }
                });
            }
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            ListView.PropertyChanged -= ListView_PropertyChanged;
            ListView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion
    }
    #endregion
}
