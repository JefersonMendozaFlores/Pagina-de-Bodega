using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace PrjProyecto_Tienda_Bodega
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //boton ingresar
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

            SqlConnection sqlconectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("usp_login", sqlconectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = tbCorreo.Text;
            cmd.Parameters.Add("@contraseña", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            //
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //agregamos una sesion de usuario
                Response.Redirect("Menu.aspx");
            }
            else
            {
                lblError.Text = "Error de usuario o contraseña";
            }
            cmd.Connection.Close();
        }
    }
}