using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class MachineryDat
    {
        // Método para mostrar Maquinarias
        public DataSet showMachinery()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectMaquinaria";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar una Maquinaria
        public bool saveMachinery(string _nombre, string _descripcion, string _clasificacion, int _fkCultivo, int _fkParcela)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertMaquinaria";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ma_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("ma_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("ma_clasificacion", MySqlDbType.VarString).Value = _clasificacion;
            objSelectCmd.Parameters.Add("tbl_cultivo_cul_id", MySqlDbType.Int32).Value = _fkCultivo;
            objSelectCmd.Parameters.Add("tbl_cultivo_tbl_parcela_par_id", MySqlDbType.Int32).Value = _fkParcela;
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

        //Método para actualizar una Maquinaria
        public bool updateMachinery(int _idMachinery, string _nombre, string _descripcion, string _clasificacion, int _fkCultivo, int _fkParcela)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateMaquinaria";
            objSelectCmd.Parameters.Add("ma_id", MySqlDbType.VarString).Value = _idMachinery;
            objSelectCmd.Parameters.Add("ma_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("ma_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("ma_clasificacion", MySqlDbType.VarString).Value = _clasificacion;
            objSelectCmd.Parameters.Add("tbl_cultivo_cul_id", MySqlDbType.Int32).Value = _fkCultivo;
            objSelectCmd.Parameters.Add("tbl_cultivo_tbl_parcela_par_id", MySqlDbType.Int32).Value = _fkParcela;
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

        //Método para eliminar una Maquinaria
        public bool deleteeMachinery(int _idMachinery)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteMaquinaria";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ma_id", MySqlDbType.Int32).Value = _idMachinery;
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