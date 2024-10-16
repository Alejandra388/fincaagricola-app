using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class SaleDat
    {
        Persistence objPer = new Persistence();
        public DataSet showSale()
        {          
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectSale";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public bool saveSale(string _fecha, int _total, int _fkProductosId, int _fkProId, int _fkCatId, int _fkCliId)
        {
        bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertSale"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ven_fecha", MySqlDbType.VarString).Value = _fecha;
            objSelectCmd.Parameters.Add("ven_total", MySqlDbType.Int32).Value = _total;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int32).Value = _fkProductosId;
            objSelectCmd.Parameters.Add("tbl_productos_tbl_proveedor_pro_id", MySqlDbType.Int).Value = _fkProId;
            objSelectCmd.Parameters.Add("tbl_productos_tbl_categoria_cat_id", MySqlDbType.Int32).Value = _fkCatId;
            objSelectCmd.Parameters.Add("tbl_cliente_cli_id", MySqlDbType.Int32).Value = _fkCliId;

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
        public bool updateSale(string _fecha, int _total, int _fkProductosId, int _fkProId, int _fkCatId, int _fkCliId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateSale"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del producto.
            objSelectCmd.Parameters.Add("ven_fecha", MySqlDbType.VarString).Value = _fecha;
            objSelectCmd.Parameters.Add("ven_total", MySqlDbType.Int).Value = _total;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int).Value = _fkProductosId;
            objSelectCmd.Parameters.Add("tbl_productos_tbl_proveedor_pro_id", MySqlDbType.Int32).Value = _fkProId;
            objSelectCmd.Parameters.Add("tbl_productos_tbl_categoria_cat_id", MySqlDbType.Int).Value = _fkCatId;
            objSelectCmd.Parameters.Add("tbl_cliente_cli_id", MySqlDbType.Int32).Value = _fkCliId;
            

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

        
        public bool deleteSale(int _idVen)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteSale"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("Ven_id", MySqlDbType.Int32).Value = _idVen;
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