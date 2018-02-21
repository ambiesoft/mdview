using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mdview
{
    
    public class CacheFile
    {
        string _cachefilename;
        string _mdfilename;
        DateTime _dtLW;
        long _size;
        public CacheFile(string mdfilename, string cachefilename)
        {
            _mdfilename = mdfilename;
            _cachefilename = cachefilename;

            UpdateCacheTime();
        }
        public void UpdateCacheTime()
        {
            try
            {
                FileInfo fi = new FileInfo(_cachefilename);
                _dtLW = fi.LastWriteTime;
                _size = fi.Length;
            }
            catch (Exception) { }
        }
        public string CacheFileName
        {
            get { return _cachefilename; }
        }
        public string MDFileName
        {
            get { return _mdfilename; }
        }
        public void Delete()
        {
            try
            {
                FileInfo fi = new FileInfo(_cachefilename);
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
