using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCaseOffScreenRender
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayCapturedPhoto : ContentPage
    {
        private ImageSource photo;
        public ImageSource Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public DisplayCapturedPhoto()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
    }
}