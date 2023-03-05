using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration; // leer web.config
using System.Data; // propiedades para los elementos de  ADO .Net
using System.Data.SqlClient; // utilizar los elementos de SQL Client
using PrjProyecto_Tienda_Bodega.Models; // utilizar los modelos

namespace PrjProyecto_Tienda_Bodega.Controllers
{
    public class ProductosDAO
    {
        string cad_cn = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        // INSERTAR PRODUCTO A LA BASE DE DATOS
        public String InsertarProducto(Productos obj)
        {
            String mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("usp_registrarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 1 parámetro
                cmd.Parameters.AddWithValue("@idProv", obj.idProveedor);
                cmd.Parameters.AddWithValue("@idCateg", obj.idCategoria);
                cmd.Parameters.AddWithValue("@stock", obj.stock);
                cmd.Parameters.AddWithValue("@precUni", obj.precioUnitario);
                //
                cmd.ExecuteNonQuery();
                //
                mensaje = "Se registro de manera correcta";
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
            //
        }

        // ACTUALIZAR PRODUCTO A LA BASE DE DATOS
        public string ActualizarProductos(Productos obj)
        {
            string mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("usp_actualizar_producto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 1 parámetro
                cmd.Parameters.AddWithValue("@idProducto", obj.idProducto);
                cmd.Parameters.AddWithValue("@stock", obj.stock);
                cmd.Parameters.AddWithValue("@precioUnitario", obj.precioUnitario);
                //
                cmd.ExecuteNonQuery();
                //
                mensaje = "El Producto: " + obj.idProducto + " Fue Actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            //
            return mensaje;

        }

        // LISTAR  PRODUCTOS
        public List<Productos> ListarProductos()
        {
            List<Productos> lista = new List<Productos>();
            //
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open();
            //
            SqlCommand cmd = new SqlCommand("usp_listar_productos", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //
            SqlDataReader dr = cmd.ExecuteReader();
            //
            Productos var_modelo = null;
            //
            while (dr.Read())
            {
                var_modelo = new Productos()
                {
                    // llenar los campos del modelo desde el datareader
                    idProducto = dr.GetInt32(0),
                    idProveedor = dr.GetInt32(1),
                    idCategoria = dr.GetInt32(2),
                    stock = dr.GetInt32(3),
                    precioUnitario = dr.GetDecimal(4)
                };
                //
                lista.Add(var_modelo);
            }
            //
            dr.Close();
            //
            cnx.Close();
            //
            return lista;
        }
    }
}