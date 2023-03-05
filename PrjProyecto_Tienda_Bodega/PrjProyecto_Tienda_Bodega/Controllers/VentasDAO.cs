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
    public class VentasDAO
    {
        string cad_cn =
        ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

		public List<Ventas> us_consulta_ventas(int idVenta)
		{
			List<Ventas> lista = new List<Ventas>();
			//
			SqlConnection cnx = new SqlConnection(cad_cn);
			cnx.Open();
			//
			SqlCommand cmd = new SqlCommand("usp_consulta_venta", cnx);
			cmd.CommandType = CommandType.StoredProcedure;
			//
			cmd.Parameters.AddWithValue("@idVenta", idVenta);
			//
			SqlDataReader dr = cmd.ExecuteReader();
			//
			Ventas var_modelo = null;
			//
			while (dr.Read())
			{
				var_modelo = new Ventas()
				{
					// llenar los campos del modelo desde el datareader
					idVenta = dr.GetInt32(0),
					nombresCliente = dr.GetString(1),
					nombreVendedor = dr.GetString(2),
					fechaVenta = dr.GetDateTime(3),
					idProducto = dr.GetInt32(4),
					descripcion = dr.GetString(5),
					marca = dr.GetString(6),
					cantidad = dr.GetInt32(7),
					precioUnitario = dr.GetDecimal(8),
					total = dr.GetDecimal(9)
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

		public String InsertarVenta(ReVentas obj)
		{
			String mensaje = "";
			//
			SqlConnection cn = new SqlConnection(cad_cn);
			try
			{
				cn.Open();
				//
				SqlCommand cmd = new SqlCommand("usp_registrarVenta", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				// 1 parámetro
				cmd.Parameters.AddWithValue("@idCli", obj.idCliente);
				cmd.Parameters.AddWithValue("@idVend", obj.idVendedor);
				cmd.Parameters.AddWithValue("@fecVenta", obj.fechaVenta);
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

		public String InsertarDetalleVenta(ReDetalleVentas obj)
		{
			String mensaje = "";
			//
			SqlConnection cn = new SqlConnection(cad_cn);
			try
			{
				cn.Open();
				//
				SqlCommand cmd = new SqlCommand("usp_registrarDetalleVenta", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				// 1 parámetro
				cmd.Parameters.AddWithValue("@idVenta", obj.idVenta);
				cmd.Parameters.AddWithValue("@idProd", obj.idProducto);
				cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
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

        // PARA EL REPORTE
        public List<Ventas> usp_reporte_ventas()
        {
            List<Ventas> lista = new List<Ventas>();
            //
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open();
            //
            SqlCommand cmd = new SqlCommand("usp_reporte_venta", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //
            SqlDataReader dr = cmd.ExecuteReader();
            //
            Ventas var_modelo = null;
            //
            while (dr.Read())
            {
                var_modelo = new Ventas()
                {
                    // llenar los campos del modelo desde el datareader
                    idVenta = dr.GetInt32(0),     
                    fechaVenta = dr.GetDateTime(1),
                    idProducto = dr.GetInt32(2),
                    descripcion = dr.GetString(3),
                    marca = dr.GetString(4),
                    cantidad = dr.GetInt32(5),
                    precioUnitario = dr.GetDecimal(6)
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