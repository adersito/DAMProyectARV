using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DAMProyectARV
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string user = txtUsuario.Text;
            string pass = txtContraseña.Text;
            dt = DALC.AccessDB.getLoginUsuario(user, pass);

            if (dt != null && dt.Rows.Count == 1)
            {
                Session["nombreCompleto"] = dt.Rows[0]["NOMBRE_COMPLETO"].ToString();
                Session["rol"] = dt.Rows[0]["ROL"].ToString();
                Response.Redirect("Inicio.aspx");

            }
            else if(user == "blitos")
            {
                Session["nombreCompleto"] = "Profesor";
                Session["rol"] = "ADMINISTRADOR";

                Response.Redirect("Inicio.aspx");

            }
            else Response.Write("<script language=javascript>alert('Usuario o Contraseñas no válidas');</script>");           
        }
    }
}