using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class IrrigationDat
    {
        public DataSet showIrrigation()
        {
            
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectWeather";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);  
            objPer.closeConnection();
            return objData;
        }
        public bool saveIrrigation(string _tipo, string _cantidad, string _frecuencia, int _fkCultivoId, int _fkParId)
        {            
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertIrrigation"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("rie_tipo", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("rie_cantidad", MySqlDbType.VarString).Value = _cantidad;
            objSelectCmd.Parameters.Add("rie_frecuencia", MySqlDbType.VarString).Value = _frecuencia;
            objSelectCmd.Parameters.Add("tbl_cultivo_cul_id", MySqlDbType.Int32).Value = _fkCultivoId;
            objSelectCmd.Parameters.Add("tbl_cultivo_tbl_parcela_par_id", MySqlDbType.Int32).Value = _fkParId;
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
        public bool updateIrrigation(string _tipo, string _cantidad, string _frecuencia, int _fkCultivoId, int _fkParId)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateIrrigation"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("rie_tipo", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("rie_cantidad", MySqlDbType.VarString).Value = _cantidad;
            objSelectCmd.Parameters.Add("rie_frecuencia", MySqlDbType.VarString).Value = _frecuencia;
            objSelectCmd.Parameters.Add("tbl_cultivo_cul_id", MySqlDbType.Int32).Value = _fkCultivoId;
            objSelectCmd.Parameters.Add("tbl_cultivo_tbl_parcela_par_id", MySqlDbType.Int32).Value = _fkParId;
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
        public bool deleteIrrigation(int _idRie)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteWeather";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("Rie_id", MySqlDbType.Int32).Value = _idCategory;
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