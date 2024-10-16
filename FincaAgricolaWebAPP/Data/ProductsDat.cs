using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class ProductsDat
    {
        Persistence objPer = new Persistence();

        //Metodo para guardar un nuevo producto
        public bool saveProducts(string _name, string _description, int _quantity, double _price, string _img, int _fkProvider, int _fkCategory)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objSelectCmd.Parameters.Add("pro_nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("pro_descripcion", MySqlDbType.VarString).Value = _description;
            objSelectCmd.Parameters.Add("pro_cantidad", MySqlDbType.Int32).Value = _quantity;
            objSelectCmd.Parameters.Add("p_precio", MySqlDbType.Double).Value = _price;
            objSelectCmd.Parameters.Add("pro_img", MySqlDbType.VarString).Value = _img;
            objSelectCmd.Parameters.Add("tbl_proveedor_pro_id", MySqlDbType.Int32).Value = _fkProvider;
            objSelectCmd.Parameters.Add("tbl_categoria_cat_id", MySqlDbType.Int32).Value = _fkCategory;

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

    // Método para mostrar los productos
    public DataSet showProducts()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();            
            objSelectCmd.CommandText = "procSelectProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;            
            objAdapter.SelectCommand = objSelectCmd;            
            objAdapter.Fill(objData);            
            objPer.closeConnection();         
            return objData;
        }

    //Metodo para actulizar un producto
    public bool updateProducts(int _id, string _name, string _description, int _quantity, double _price, string _img, int _fkProvider, int _fkCategory)
    {
        bool executed = false;
        int row;

        MySqlCommand objSelectCmd = new MySqlCommand();
        objSelectCmd.Connection = objPer.openConnection();
        objSelectCmd.CommandText = "procUpdateProduct";
        objSelectCmd.CommandType = CommandType.StoredProcedure;

        objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
        objSelectCmd.Parameters.Add("pro_nombre", MySqlDbType.VarString).Value = _name;
        objSelectCmd.Parameters.Add("pro_descripcion", MySqlDbType.VarString).Value = _description;
        objSelectCmd.Parameters.Add("pro_cantidad", MySqlDbType.Int32).Value = _quantity;
        objSelectCmd.Parameters.Add("p_precio", MySqlDbType.Double).Value = _price;
        objSelectCmd.Parameters.Add("pro_img", MySqlDbType.VarString).Value = _img;
        objSelectCmd.Parameters.Add("tbl_proveedor_pro_id", MySqlDbType.Int32).Value = _fkProvider;
        objSelectCmd.Parameters.Add("tbl_categoria_cat_id", MySqlDbType.Int32).Value = _fkCategory;

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
    public bool deleteProducts(int _idProduct)
    {
        bool executed = false;
        int row;

        MySqlCommand objSelectCmd = new MySqlCommand();
        objSelectCmd.Connection = objPer.openConnection();
        objSelectCmd.CommandText = "procDeleteProduct";
        objSelectCmd.CommandType = CommandType.StoredProcedure;
        objSelectCmd.Parameters.Add("pro_id", MySqlDbType.Int32).Value = _idCategory;

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