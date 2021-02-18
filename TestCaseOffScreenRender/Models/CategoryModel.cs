using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestCaseOffScreenRender.Models
{
    public class CategoryModel : BaseModel
    {
        public ICommand Click { get; private set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }
        private bool expanded;
        public bool Expanded
        {
            get { return expanded; }
            set
            {
                SetField(ref expanded, value);
                OnPropertyChanged("Collapsed");
            }
        }
        public int Count { get { return items.Count; } }
        private ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> Items
        {
            get { return items; }
            set { SetField(ref items, value); }
        }

        public CategoryModel()
        {
            Click = new Command<CategoryModel>(execute: (category) =>
            {
                category.Expanded = !category.Expanded;
            });
            items.CollectionChanged += (s, e) => { OnPropertyChanged("Count"); };
        }
    }
}
