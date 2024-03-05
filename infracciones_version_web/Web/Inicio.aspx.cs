using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;

namespace Web
{
    public partial class _Default : Page
    {
        private Agencia a;
        private string lugarBase;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lugarBase = Server.MapPath(@"baseAgencia.mdb");
                Agencia.PonerPathABaseAccess(lugarBase);
                a = new Agencia();
                Session["Agencia"] = a;
            }
        }

        public void recuperarAgencia ()
        {
            a = (Agencia)Session["Agencia"];
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            recuperarAgencia();


                string dom = TextBoxDominio.Text;

                if (dom.Length != 0)
                {

                }

                Vehiculo v = a.buscameVehiculo(dom);

                if (v != null) //existe. lleno el listbox.
                {
                List<Multa> listaOriginal = v.ListaMultas;

                ListBoxMultas.DataSource = listaOriginal;
                ListBoxMultas.DataBind();
                ListBoxMultas.ClearSelection();

                }

        }

        protected void ButtonPago_Click(object sender, EventArgs e) //generar orden de pago
        {

            recuperarAgencia();
            
          

                if (ListBoxMultas.SelectedItem!=null)
                {
                    string multa = ListBoxMultas.SelectedValue;
                   
                    int lugarGuion = multa.IndexOf("-");
                    
                    int codMulta = int.Parse(multa.Substring(0, lugarGuion-1)); 
                    

                    a.registrarPago(codMulta);
                    a.actualizarMulta(codMulta); //actualizo el registro en bd
                    TextBoxPrueba.Text = "Pagada Exitosamente";

                    OrdenPago o = a.buscameOrdenParaFormulario(codMulta);
                    if (o!=null)
                    {
                    Session["OrdenPago"] = o;
                    Response.Redirect("OrdenDePago.aspx");
                    }
                    
            }
               
  

     
        }

        protected void Button1_Click(object sender, EventArgs e) //salir
        {
            Session.Clear();
            Session.Abandon();
        }

    }
    }