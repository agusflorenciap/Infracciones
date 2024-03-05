using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using Excepciones;

namespace PlayerUI
{
    public partial class FPagoMultaSiguiente : Form
    {
        private Multa m;
        OrdenPago pago;
        private double importeNeto;

        
        public FPagoMultaSiguiente(Multa seleccionada)
        {
            m = seleccionada;
            InitializeComponent();

            labelCod.Text = m.Cod.ToString();
            labelDesc.Text = m.Desc.ToString();
            labelGravedad.Text = m.decimeGravedad().ToString();
            textBoxFechaE.Text = m.FechaCreacion.ToString();
            textBoxFechaV.Text = m.FechaVencimiento.ToString();

            if (DateTime.Today>m.FechaVencimiento) //muestro que está vencida
                  labelVencida.Visible = true;

            labelImporte.Text = m.Importe.ToString();
            importeNeto = m.dameImporteNeto();
            labelImporteNeto.Text = importeNeto.ToString();

        }


        public OrdenPago OrdenGenerada
        {
            get { return pago; }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
           pago = new OrdenPago(m.Cod, importeNeto, DateTime.Today);
 
           this.Close();
        }

        
    }
}
