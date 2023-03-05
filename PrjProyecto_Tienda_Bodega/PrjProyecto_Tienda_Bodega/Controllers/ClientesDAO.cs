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
    public class ClientesDAO
    {
        string cad_cn = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        // INSERTAR NUEVO CLIENTE
        public String InsertarCliente(Clientes obj)
        {
            String mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("usp_registrarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 1 parámetro
                cmd.Parameters.AddWithValue("@nombre", obj.nombres);
                cmd.Parameters.AddWithValue("@apellidos", obj.apellidos);
                cmd.Parameters.AddWithValue("@fecNac", obj.fechaNacimiento);
                cmd.Parameters.AddWithValue("@celular", obj.celular);
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

        // LSITAR TODOS LOS CLIENTES
        public List<Clientes> ListarClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            //
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open();
            //
            SqlCommand cmd = new SqlCommand("usp_listar_clientes", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //
            SqlDataReader dr = cmd.ExecuteReader();
            //
            Clientes var_modelo = null;
            //
            while (dr.Read())
            {
                var_modelo = new Clientes()
                {
                    // llenar los campos del modelo desde el datareader
                    idCliente = dr.GetInt32(0),
                    nombres = dr.GetString(1),
                    apellidos = dr.GetString(2),
                    fechaNacimiento = dr.GetDateTime(3),
                    celular = dr.GetString(4)
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

        // ACTUALIZAR CLIENTE 
        public string ActualizarCliente(Clientes obj)
        {
            string mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("usp_actualizar_cliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 1 parámetro
                cmd.Parameters.AddWithValue("@idCliente", obj.idCliente);
                cmd.Parameters.AddWithValue("@celular", obj.celular);
                //
                cmd.ExecuteNonQuery();
                //
                mensaje = "El cliente: " + obj.idCliente + " Fue Actualizado correctamente";
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

        // REPORTE DE CLIENTE
        public List<Clientes> ReporteClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            //
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open();
            //
            SqlCommand cmd = new SqlCommand("usp_reporte_cliente", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //
            SqlDataReader dr = cmd.ExecuteReader();
            //
            Clientes var_modelo = null;
            //
            while (dr.Read())
            {
                var_modelo = new Clientes()
                {
                    // llenar los campos del modelo desde el datareader
                    idCliente = dr.GetInt32(0),
                    nombres = dr.GetString(1),
                    apellidos = dr.GetString(2),
                    fechaNacimiento = dr.GetDateTime(3),
                    celular = dr.GetString(4)
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