using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mdview
{
    
    public class CacheFile
    {
        string _filename;
        DateTime _dtLW;
        long _size;
        public CacheFile(string filename)
        {
            _filename = filename;
            try
            {
                FileInfo fi = new FileInfo(_filename);
                _dtLW = fi.LastWriteTime;
                _size = fi.Length;
            }
            catch (Exception) { }
        }

        public string FileName
        {
            get { return _filename; }
        }

        public void Delete()
        {
            try
            {
                FileInfo fi = new FileInfo(_filename);
                if (_dtLW == fi.LastWriteTime)
                {
                    if (_size == fi.Length)
                    {
                        fi.Delete();
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
