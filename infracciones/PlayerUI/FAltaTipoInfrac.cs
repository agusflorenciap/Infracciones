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
    public partial class FAltaTipoInfrac : Form
    {
        
        private TipoInfrac i;
        public FAltaTipoInfrac()
        {
            InitializeComponent();
        }

      
        public TipoInfrac TipoInfraccion
        {
            get { return i; }
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

                string nomb = textBoxNombre.Text;
                if (nomb.Length == 0)
                    throw new BlancoException();

                string gravedad = (String)comboBoxGravedad.SelectedItem; //desplegable
                if (comboBoxGravedad.SelectedIndex == -1)
                    throw new NoSeleccion();

                double importe = double.Parse(textBoxImporte.Text);
                i = new TipoInfrac (cod, nomb, gravedad, importe);
                this.Close();
            }

            catch (BlancoException ex)
            {
                MessageBox.Show(ex.Message);
                textBoxNombre.Focus();
            }

            catch (NoSeleccion ex)
            {
                MessageBox.Show(ex.Message);
                textBoxImporte.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
