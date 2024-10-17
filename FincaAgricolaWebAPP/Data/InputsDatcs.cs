using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class InputsDatcs
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todas las Inputs
        public DataSet showInputs()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectInputs";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }


        //Metodo para guardar una nueva Inputs
        public bool saveInputs(string _nombre, string _tipo, string _cantidad int _fkCultivoId, int _fkParcelaId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertInpunts";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ins_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("ins_tipo", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("ins_cantidad", MySqlDbType.VarString).Value = _cantidad;
            objSelectCmd.Parameters.Add("tbl_cultivo_cul_id", MySqlDbType.Int32).Value = _fkCultivoId;
            objSelectCmd.Parameters.Add("tbl_cultivo_tbl_parcela_par_id", MySqlDbType.Int32).Value = _fkParcelaId;
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

        //Metodo para actualizar una Inputs
        public bool updateInputs(int _idInputs, string _nombre, string _tipo, string _cantidad, int _fkCultivoId, int _fkParcelaId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateInputs";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ins_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("ins_tipo", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("ins_cantidad", MySqlDbType.VarString).Value = _cantidad;
            objSelectCmd.Parameters.Add("tbl_cultivo_cul_id", MySqlDbType.Int32).Value = _fkCultivoId;
            objSelectCmd.Parameters.Add("tbl_cultivo_tbl_parcela_par_id", MySqlDbType.Int32).Value = _fkParcelaId;
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

        //Metodo para borrar una Inputs
        public bool deleteInputs(int _idInputs)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteInputs";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ins_id", MySqlDbType.Int32).Value = _idInputs;

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