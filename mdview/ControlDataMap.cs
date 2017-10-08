using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mdview
{
    class ObjectWrapper
    {
        private object _value;

        public ObjectWrapper(object value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value==null? null:_value.ToString();
        }

        public void Set(string s)
        {
            _value = s;
        }
    }

    class ControlDataMap
    {
        Dictionary<Control, ObjectWrapper> _dic = new Dictionary<Control, ObjectWrapper>();
        public ControlDataMap()
        {

        }

        public void Add(Control c, object refst)
        {
            _dic.Add(c, new ObjectWrapper(refst));
        }

        public void Refrect(bool reverse)
        {
            foreach (Control c in _dic.Keys)
            {
                if (reverse)
                {
                    _dic[c].Set(c.Text);
                }
                else
                {
                    c.Text = _dic[c].ToString() != null ? _dic[c].ToString() : "";
                }
            }
                
        }
    }
}
