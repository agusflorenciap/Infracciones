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
    public partial class FAgregarMulta : Form
    {
        private Agencia a;
        private Multa m;
        public FAgregarMulta(Agencia agencia)
        {
            a = agencia;
            InitializeComponent();
            listBoxTiposInfrac.DataSource = null;
            listBoxTiposInfrac.DataSource = a.ListaTipoDeInfrac;
            listBoxTiposInfrac.ClearSelected();
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
            try
            {
                int cod = int.Parse(textBoxCodigo.Text);

                string dominio = textBoxDominio.Text;
                if (dominio.Length == 0)
                    throw new BlancoException();

                Vehiculo v = a.buscameVehiculo(dominio);

                if (v==null)
                    throw new InexistenciaVehiculo();

                string desc = textBoxDesc.Text;
                if (desc.Length == 0)
                    throw new BlancoException();

                TipoInfrac i = (TipoInfrac)listBoxTiposInfrac.SelectedItem; //desplegable
                if (i == null)
                    throw new NoSeleccion();

                double importe = i.Precio;

                DateTime fechaSuceso = dateTimePicker1.Value;
                DateTime fechaVenci = fechaSuceso.AddDays(30); //+30dias

                bool paga = false;

                m = new Multa(cod, dominio, desc, i, importe, fechaSuceso, fechaVenci,paga);
                a.registrarMulta(m);
                v.sumateMulta(m);
                a.GuardarEnTablaMulta_TipoInfrac(i.Cod, cod);
                a.GuardarEnTablaMultas_Vehiculo(dominio, cod);


                this.Close();
            }

            catch (BlancoException ex)
            {
                MessageBox.Show(ex.Message);
                textBoxDominio.Focus();
            }

            catch (InexistenciaVehiculo ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (NoSeleccion ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
