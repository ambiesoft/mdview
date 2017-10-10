//BSD 2-Clause License
//
//Copyright (c) 2017, Ambiesoft
//All rights reserved.
//
//Redistribution and use in source and binary forms, with or without
//modification, are permitted provided that the following conditions are met:
//
//* Redistributions of source code must retain the above copyright notice, this
//  list of conditions and the following disclaimer.
//
//* Redistributions in binary form must reproduce the above copyright notice,
//  this list of conditions and the following disclaimer in the documentation
//  and/or other materials provided with the distribution.
//
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
//FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
//OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

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
