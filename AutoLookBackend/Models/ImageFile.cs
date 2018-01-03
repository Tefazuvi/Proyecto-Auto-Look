using System;
using System.Collections.Generic;

namespace AutoLookBackend.Models
{
    public class ImageFile
    {
        #region Variables
        Conexion conexionM = new Conexion();
        #endregion

        public ImageFile()
        {
        }

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

    }
}
