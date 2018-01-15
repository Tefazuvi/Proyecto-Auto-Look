
using System;
using System.IO;

using Xamarin.Forms;

namespace AutoLook.Model
{
    public class ImageFile
    {
        public string Path
        {
            get;
            set;
        }

        public Byte[] Image
        {
            get;
            set;
        }

        public ImageFile()
        {
        }

    }
}