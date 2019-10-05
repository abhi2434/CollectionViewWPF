using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

namespace CollectionviewSourceSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView source;

        public string[] DeveloperList { get; }

        public MainWindow()
        {
            InitializeComponent();
            var items = ModelFactory.Build();
            this.source = CollectionViewSource.GetDefaultView(items);
            this.DeveloperList = items.Select(t => t.Developer).Distinct().ToArray();
            grdMain.DataContext = this;

            this.lvItems.DataContext = source;
  
        }


        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader currentHeader = e.OriginalSource as GridViewColumnHeader;
            if (currentHeader != null && currentHeader.Role != GridViewColumnHeaderRole.Padding)
            {
                using (this.source.DeferRefresh())
                {
                    Func<SortDescription, bool> lamda = item => item.PropertyName.Equals(currentHeader.Column.Header.ToString());
                    if (this.source.SortDescriptions.Count(lamda) > 0)
                    {
                        SortDescription currentSortDescription = this.source.SortDescriptions.First(lamda);
                        ListSortDirection sortDescription = currentSortDescription.Direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;


                        currentHeader.Column.HeaderTemplate = currentSortDescription.Direction == ListSortDirection.Ascending ?
                            this.Resources["HeaderTemplateArrowDown"] as DataTemplate : this.Resources["HeaderTemplateArrowUp"] as DataTemplate;

                        this.source.SortDescriptions.Remove(currentSortDescription);
                        this.source.SortDescriptions.Insert(0, new SortDescription(currentHeader.Column.Header.ToString(), sortDescription));
                    }
                    else
                        this.source.SortDescriptions.Add(new SortDescription(currentHeader.Column.Header.ToString(), ListSortDirection.Ascending));
                }
            }
        }

        private void buttonAppy_Click(object sender, RoutedEventArgs e)
        {
            this.source.Filter = item =>
            {
                PropertyInfo info = item.GetType().GetProperty(FilterControl.Property);
                if (info == null)
                    return false;

                return info.GetValue(item, null).ToString().Contains(FilterControl.Value);
            };
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.source.Filter = item => true;
        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            this.source.GroupDescriptions.Clear();

            PropertyInfo pinfo = typeof(ViewItem).GetProperty(GroupControl.Property);
            if (pinfo != null)
                this.source.GroupDescriptions.Add(new PropertyGroupDescription(pinfo.Name));

        }

        private void btnClearGr_Click(object sender, RoutedEventArgs e)
        {
            this.source.GroupDescriptions.Clear();
        }

        private void btnNavigation_Click(object sender, RoutedEventArgs e)
        {
            Button CurrentButton = sender as Button;

            switch (CurrentButton.Tag.ToString())
            {
                case "0":
                    this.source.MoveCurrentToFirst();
                    break;
                case "1":
                    this.source.MoveCurrentToPrevious();
                    break;
                case "2":
                    this.source.MoveCurrentToNext();
                    break;
                case "3":
                    this.source.MoveCurrentToLast();
                    break;
            }

        }

        private void btnEvaluate_Click(object sender, RoutedEventArgs e) =>


            MessageBox.Show(this.lvItems.SelectedItem.GetType()
                .GetProperties()
                .ToDictionary(a => a.Name, a => a.GetValue(this.lvItems.SelectedItem, null))
                .Aggregate(new StringBuilder(), (a, b) => a.Append(b.Key + " : " + b.Value + "  "))
                .ToString());


    }

}
