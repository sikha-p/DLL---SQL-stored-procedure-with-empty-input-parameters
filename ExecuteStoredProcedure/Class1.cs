using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExecuteStoredProcedure
{
    public class Class1
    {
        public static string executeSP(string connectionString, string storedProcedure, string parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con;
                //Here we declare the parameter which we have to use in our application  
                SqlCommand cmd = new SqlCommand();
                SqlParameter sp1 = new SqlParameter();
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                string[] parameters_ = parameters.Split(';');
                for (int i = 0; i < parameters_.Length; i++)
                {
                    string[] keyValue = parameters_[i].Split('=');
                    cmd.Parameters.Add("@" + keyValue[0], SqlDbType.NVarChar).Value = keyValue[1];
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Stored procedure executed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
