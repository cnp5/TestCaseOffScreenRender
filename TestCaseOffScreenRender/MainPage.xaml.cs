using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCaseOffScreenRender
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public List<Models.CategoryModel> Categories { get; set; } = new List<Models.CategoryModel>();
            
        public MainPage()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Models.CategoryModel category;
                category = new Models.CategoryModel()
                {
                    Name = $"Category {i:00}"
                };
                for (int j = 0; j < 10; j++)
                {
                    category.Items.Add(new Models.ItemModel()
                    {
                        Name = $"Item {i:00}-{j:00}",
                        Description = $"Decription Category:{i:00} Item:{j:00}",
                    });
                }
                this.Categories.Add(category);
            }
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        //Testing Xamarin.Essentials.MediaPicker in Xiaomi phone, taking photo results in a 90 degrees clockwise photo
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                var page = new DisplayCapturedPhoto();
                using (MemoryStream ms = new MemoryStream())
                using (Stream stream = await photo.OpenReadAsync())
                {
                    await stream.CopyToAsync(ms);
                    page.Photo = ImageSource.FromStream(() => new MemoryStream(ms.ToArray()));
                }
                if (File.Exists(photo.FullPath))
                    File.Delete(photo.FullPath);

                await this.Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
    }
}
