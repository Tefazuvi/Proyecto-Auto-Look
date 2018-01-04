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

        public string SaveImageFile(Byte[] NewImage, int vehicleID)
        {
            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                lstParams.Add(new ParameterSchema("Picture", NewImage));
                lstParams.Add(new ParameterSchema("Vehicles_id", vehicleID));

                query = "INSERT INTO Pictures (Picture,Vehicles_id) " +
                    "values(@Picture,@Vehicles_id)";

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
