using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestCaseOffScreenRender.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestCaseOffScreenRender.ViewModels
{
    public class MainPageModel : BaseModel
    {
        public ICommand TakePhotoCommand { get; private set; }

        private ObservableCollection<Models.CategoryModel> categories = new ObservableCollection<CategoryModel>();
        public ObservableCollection<Models.CategoryModel> Categories
        {
            get { return categories; }
            set { SetField(ref categories, value); }
        } 

        public MainPageModel()
        {
            TakePhotoCommand = new Command(async (s) => await TakePhotoCommandExecute());
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
        }

        //Testing Xamarin.Essentials.MediaPicker in Xiaomi phone, taking photo results in a 90 degrees clockwise photo
        private async Task TakePhotoCommandExecute()
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            var page = new DisplayCapturedPhoto();
            var model = page.BindingContext as DisplayCapturedPhotoModel;

            using (MemoryStream ms = new MemoryStream())
            using (Stream stream = await photo.OpenReadAsync())
            {
                await stream.CopyToAsync(ms);
                model.Photo = ImageSource.FromStream(() => new MemoryStream(ms.ToArray()));
            }
            if (File.Exists(photo.FullPath))
                File.Delete(photo.FullPath);

            await App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
