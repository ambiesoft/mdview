using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mdview
{
    class ComboLangItem
    {
        string display_;
        string lang_;

        public ComboLangItem(string disp, string lang)
        {
            display_ = disp;
            lang_ = lang;
        }
        public override string ToString() 
        {
            return display_;
        }
        public string Language
        {
            get
            {
                return lang_;
            }
        }
    }
}
