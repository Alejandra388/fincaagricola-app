using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class ClientDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todas las Categorias
        public DataSet showClient()
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


        //Metodo para guardar una nueva Categoria
        public bool saveClient(string _nombre, string _correo, string _contraseña, string _direccion, string _ciudad)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertClient";
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

        //Metodo para actualizar una Categoria
        public bool updateClient(string _nombre, string _correo, string _contraseña, string _direccion, string _ciudad)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateClient";
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

        //Metodo para borrar una Categoria
        public bool deleteClient(int _idCategory)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cli_id", MySqlDbType.Int32).Value = _idCategory;

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