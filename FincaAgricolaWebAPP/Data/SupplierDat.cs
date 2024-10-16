﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class SupplierDat
    {
        Persistence objPer = new Persistence();

        //Método para guardar un Proveedor
        public bool saveSupplier(int _nit, string _name, int _fkFincaId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertProveedor";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("pro_nit", MySqlDbType.Int32).Value = _nit;
            objSelectCmd.Parameters.Add("pro_nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("tbl_finca_fin_id", MySqlDbType.Int32).Value = _fkFincaId;

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

        //Metodo para mostrar Proveedores
        public DataSet showSupplier()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelecProveedor";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para actualizar un Proveedor
        public bool updateCategory(int _idSupp, int _nit, string _name, int _fkFincaId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateProveedor";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("pro_id", MySqlDbType.Int32).Value = _idSupp;
            objSelectCmd.Parameters.Add("pro_nit", MySqlDbType.VarString).Value = _nit;
            objSelectCmd.Parameters.Add("pro_nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("tbl_finca_fin_id", MySqlDbType.VarString).Value = _fkFincaId;

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

        //Metodo para borrar un Proveedor
        public bool deleteCategory(int _idSupp)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteProveedor";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("pro_id", MySqlDbType.Int32).Value = _idSupp;

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