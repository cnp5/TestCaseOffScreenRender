using System;
using System.Collections.Generic;
using System.Text;
using TestCaseOffScreenRender.Models;
using Xamarin.Forms;

namespace TestCaseOffScreenRender.ViewModels
{
    public class DisplayCapturedPhotoModel : BaseModel
    {
        private ImageSource photo;
        public ImageSource Photo
        {
            get { return photo; }
            set
            {
                SetField(ref photo, value);
            }
        }
    }
}
