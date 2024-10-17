using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Data
{
    public class ParcelDat
    {
        Persistence objPer = new Persistence();
        //Metodo para mostrar todas las Parcelas
        public DataSet showCategories()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectParcela";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
       

        //Metodo para guardar una nueva Parcela
        public bool saveCategory(int _dimenciones, string _ubicacion, int _fkfinca, int _fkclima)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertParcela"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("par_ubicacion", MySqlDbType.DateTime).Value = _ubicacion;
            objSelectCmd.Parameters.Add("par_dimenciones", MySqlDbType.Int32).Value = _dimenciones;
            objSelectCmd.Parameters.Add("tbl_finca_fin_id", MySqlDbType.Int32).Value = _fkfinca;
            objSelectCmd.Parameters.Add("par_tbl_clima_id", MySqlDbType.Int32).Value = _fkclima;

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

        //Metodo para actualizar una Parcela
        public bool updateCategory(int _idFinca, int _dimenciones, string _ubicacion, int _fkfinca, int _fkclima)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateParcela"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("par_id", MySqlDbType.Int32).Value = _idFinca;
            objSelectCmd.Parameters.Add("par_ubicacion", MySqlDbType.DateTime).Value = _ubicacion;
            objSelectCmd.Parameters.Add("par_dimenciones", MySqlDbType.Int32).Value = _dimenciones;
            objSelectCmd.Parameters.Add("tbl_finca_fin_id", MySqlDbType.Int32).Value = _fkfinca;
            objSelectCmd.Parameters.Add("tbl_clima_clim_id", MySqlDbType.Int32).Value = _fkclima;

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

        //Metodo para borrar una Parcela
        public bool deleteCategory(int _idParcela)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteParcela"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("par_id", MySqlDbType.Int32).Value = _idParcela;

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