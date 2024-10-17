using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class UserDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todos los usuarios
        public DataSet showUsers()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectUser";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para guardar un nuevo usuario
        public bool saveUser(string _nombre, string _correo, string _contrasena, string _rol, string _direccion, string _ciudad)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertUser";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("usu_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("usu_correo", MySqlDbType.DateTime).Value = _correo;
            objSelectCmd.Parameters.Add("usu_contrasena", MySqlDbType.DateTime).Value = _contrasena;
            objSelectCmd.Parameters.Add("usu_rol", MySqlDbType.VarString).Value = _rol;
            objSelectCmd.Parameters.Add("usu_direccion", MySqlDbType.DateTime).Value = _direccion;
            objSelectCmd.Parameters.Add("usu_ciudad", MySqlDbType.DateTime).Value = _ciudad;

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

        //Metodo para actualizar un usuario
        public bool updateUser(int _idUser, string _nombre, string _correo, string _contrasena, string _rol, string _direccion, string _ciudad)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateUser";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("usu_id", MySqlDbType.VarString).Value = _idClient;
            objSelectCmd.Parameters.Add("usu_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("usu_correo", MySqlDbType.DateTime).Value = _correo;
            objSelectCmd.Parameters.Add("usu_contrasena", MySqlDbType.DateTime).Value = _contrasena;
            objSelectCmd.Parameters.Add("usu_rol", MySqlDbType.DateTime).Value = _rol;
            objSelectCmd.Parameters.Add("usu_direccion", MySqlDbType.DateTime).Value = _direccion;
            objSelectCmd.Parameters.Add("usu_ciudad", MySqlDbType.DateTime).Value = _ciudad;

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

        //Metodo para borrar un usuario
        public bool deleteUser(int _idUser)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteUser";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cli_id", MySqlDbType.Int32).Value = _idUser;

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
}