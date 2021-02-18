using System;
using System.Collections.Generic;
using System.Text;

namespace TestCaseOffScreenRender.Models
{
    public class ItemModel : BaseModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { SetField(ref description, value); }
        }
    }
}
