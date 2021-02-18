using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestCaseOffScreenRender.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public void SetField<T>(ref T variable, T value, [CallerMemberName] string name = "")
        {
            variable = value;
            OnPropertyChanged(name);
        }
    }
}
