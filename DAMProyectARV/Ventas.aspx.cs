using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAMProyectARV
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable auxVentas = new DataTable();
                auxVentas = formatDataTable();
                Session["dtAuxventas"] = auxVentas;
                

            }
        }




        protected void botonAñadir(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable aux = (DataTable)Session["dtAuxventas"];
            
            bool sw = Convert.ToBoolean(Session["switchVentas"]);

            string codigoProducto = txtProducto.Text;
            dt = DALC.AccessDB.getProducto(codigoProducto);            
            if (dt.Rows.Count > 0)
            {              
                foreach (DataRow row in dt.Rows)
                {
                    if (sw)
                    {
                        foreach (GridViewRow gridr in Grid_Ventas.Rows)
                        {
                            if (gridr.Cells[0].Text.Equals(row["CODIGO"].ToString())){
                                Label label = (Label)gridr.Cells[1].FindControl("labelCantidad");
                                decimal cantidadLabel;
                                cantidadLabel = Convert.ToDecimal(label.Text);
                                label.Text = (cantidadLabel + 1).ToString();
                                                              
                                foreach(DataRow r in aux.Rows)
                                {
                                    if (r[0].ToString().Equals(gridr.Cells[0].Text))
                                    {
                                        r["CANTIDAD_MOV"] = (cantidadLabel + 1).ToString();


                                    }
                                }
                                ajustarSumatorios();
                                Session["dtAuxVentas"] = aux;
                                setUpGrid();
                                return;

                            }

                    }

                    }
                    if (row["CANTIDAD_MOV"].ToString() == ""){

                        row["CANTIDAD_MOV"] = "1";

                    }

                    

                    row["TOTAL"] = (Convert.ToDecimal(row["CANTIDAD_MOV"]) * Convert.ToDecimal(row["PRECIO"]));
                    aux.Rows.Add(row.ItemArray);

                }
                Session["dtAuxVentas"] = aux;
                
                Grid_Ventas.DataSource = aux;
                Grid_Ventas.DataBind();
                setUpGrid();

                if (!sw)
                {
                    

                    Session["switchVentas"] = true;
                }
                ajustarSumatorios();


                Grid_Ventas.Visible = true;
            }
            else Response.Write("<script language=javascript>alert('Producto no encontrado');</script>");

            
            

        }

        private void ajustarSumatorios()
        {
            decimal acumuladorCantidad = 0;
            decimal acumuladorPrecio = 0;

            foreach (GridViewRow r in Grid_Ventas.Rows)
            {
                Label labelC = (Label)r.Cells[1].FindControl("labelCantidad");
                acumuladorCantidad += Convert.ToDecimal(labelC.Text);
                acumuladorPrecio += Convert.ToDecimal(r.Cells[6].Text);

            }
            Grid_Ventas.FooterRow.Cells[1].Text = acumuladorCantidad.ToString();
            Grid_Ventas.FooterRow.Cells[6].Text = acumuladorPrecio.ToString();

        }

        private DataTable formatDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CODIGO");
            dt.Columns.Add("NOMBRE");
            dt.Columns.Add("PRECIO_SIN_IVA");
            dt.Columns.Add("PRECIO");
            dt.Columns.Add("CANTIDAD");
            dt.Columns.Add("CANTIDAD_MOV");
            dt.Columns.Add("PRECIO_TOTAL");

            
            return dt;
        }

        private void setUpGrid()
        {
            Grid_Ventas.FooterRow.Cells[0].Text = "Total";
            Grid_Ventas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
             
            //Cantidad
            Grid_Ventas.FooterRow.Cells[1].Font.Bold = true;
            Grid_Ventas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //Precio total
            Grid_Ventas.FooterRow.Cells[6].Font.Bold = true;
            Grid_Ventas.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        }

        //private void defaultTable()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow r;
        //    DataColumn column;
        //    DataView view;

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "CODIGO";
        //    dt.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "CANTIDAD";
        //    dt.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "NOMBRE";
        //    dt.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "PRECIO";
        //    dt.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "TOTAL";
        //    dt.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "ELIMINAR";
        //    dt.Columns.Add(column);

        //    for (int i = 0; i < 10; i++)
        //    {
        //        r = dt.NewRow();
        //        r["CANTIDAD"] = i.ToString();
        //        r["CODIGO"] = "Código: " + i.ToString();
        //        r["NOMBRE"] = "Nombre: " + i.ToString();
        //        r["PRECIO"] = "Precio: " + (i * 100).ToString();
        //        r["TOTAL"] = "Total: " + (i * 100).ToString();
        //        r["ELIMINAR"] = "Eliminar";
        //        dt.Rows.Add(r);

        //    }
        //    view = new DataView(dt);
        //    Grid_Ventas.DataSource = view;
        //    Grid_Ventas.DataBind();
        //}

        protected void btnEliminar(object sender, EventArgs e)
        {

        }

        protected void botonRestar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label label = (Label)row.Cells[1].FindControl("labelCantidad");
            string codigo = row.Cells[0].Text;
            
            DataTable aux = (DataTable)Session["dtAuxVentas"];

            if (label.Text == "1") return;

            else
            {
                label.Text = (Convert.ToInt32(label.Text) - 1).ToString();
                
                foreach (DataRow r in aux.Rows)
                {
                    if (r["CODIGO"].Equals(codigo))
                    {
                        r["CANTIDAD_MOV"] = label.Text;


                    }

                }
                Session["dtAuxVentas"] = aux;
                ajustarSumatorios();


            }

        }

        protected void botonSumar(object sender, EventArgs e)
        {

        }

//       

    }
}