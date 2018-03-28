using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CollectionviewSourceSample
{
    public class Model
    {

        private ObservableCollection<ViewItem> items;
        public ObservableCollection<ViewItem> Items
        {
            get
            {
                this.items = this.items ?? this.LoadItems();
                return this.items;
            }
        }

        public IEnumerable<string> Columns
        {
            get
            {
                return from prop in typeof(ViewItem).GetProperties()
                       select prop.Name;
            }
        }
        public IEnumerable<string> AvailableDevelopment
        {
            get
            {
                return (from developer in this.Items
                        select developer.Developer).Distinct();
            }
        }
        private ObservableCollection<ViewItem> LoadItems()
        {
            ObservableCollection<ViewItem> items = new ObservableCollection<ViewItem>();

            items.Add(new ViewItem { Id = "1", Name = "Abhishek", Developer = "WPF", Salary = 50000.20f });
            items.Add(new ViewItem { Id = "2", Name = "Abhijit", Developer = "ASP.NET", Salary = 89000.20f });
            items.Add(new ViewItem { Id = "3", Name = "Scott", Developer = "ASP.NET", Salary = 95000.20f });
            items.Add(new ViewItem { Id = "4", Name = "Kunal", Developer = "Silverlight", Salary = 26000.20f });
            items.Add(new ViewItem { Id = "5", Name = "Hanselman", Developer = "ASP.NET", Salary = 78000.20f });
            items.Add(new ViewItem { Id = "6", Name = "Peter", Developer = "WPF", Salary = 37000.20f });
            items.Add(new ViewItem { Id = "7", Name = "Tim", Developer = "Silverlight", Salary = 45000.20f });
            items.Add(new ViewItem { Id = "8", Name = "John", Developer = "ASP.NET", Salary = 70000.20f });
            items.Add(new ViewItem { Id = "9", Name = "Shibatosh", Developer = "WPF", Salary = 40000.20f });

            return items;
        }
    }
    public class ViewItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public float Salary { get; set; }
    }
}
