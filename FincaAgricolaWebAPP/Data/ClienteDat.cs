using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class ClienteDat
    {
        public DataSet showCliente()
        {

            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        public bool saveCliente(string _nombre, string _correo, string _contraseña, string _direccion, string _ciudad)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertCliente";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cli_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("cli_correo", MySqlDbType.VarString).Value = _correo;
            objSelectCmd.Parameters.Add("cli_contraseña", MySqlDbType.VarString).Value = _contraseña;
            objSelectCmd.Parameters.Add("cli_direccion", MySqlDbType.VarString).Value = _direccion;
            objSelectCmd.Parameters.Add("cli_ciudad", MySqlDbType.VarString).Value = _ciudad;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
        public bool updateCliente(string _nombre, string _correo, string _contraseña, string _direccion, string _ciudad)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateCliente";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cli_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("cli_correo", MySqlDbType.VarString).Value = _correo;
            objSelectCmd.Parameters.Add("cli_contraseña", MySqlDbType.VarString).Value = _contraseña;
            objSelectCmd.Parameters.Add("cli_direccion", MySqlDbType.Int32).Value = _direccion;
            objSelectCmd.Parameters.Add("cli_ciudad", MySqlDbType.Int32).Value = _ciudad;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
        public bool deleteCliente(int _idRie)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("Cli_id", MySqlDbType.Int32).Value = _idCategory;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}