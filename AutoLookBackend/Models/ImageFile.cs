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

        public string SaveImageFile(ImageFile NewImage, int vehicleID)
        {
            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                //Convert the byte array to a base 64 encoded string.

                string encodedString = Convert.ToBase64String(NewImage.Image);

                lstParams.Add(new ParameterSchema("Picture", encodedString));
                lstParams.Add(new ParameterSchema("Vehicles_id", vehicleID));

                query = "INSERT INTO Pictures (Picture,Vehicles_id) " +
                    "values(@encodedString,@vehicleID)";

                return conexionM.setExecuteQuery(query, lstParams);
            }
            catch (Exception ex)
            {
                //throw ex;
                return ex.Message;
            }
        }
    }
}
