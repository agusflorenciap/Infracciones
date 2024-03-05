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
    public partial class FModifTipoInfrac : Form
    {

        private TipoInfrac i;
        public FModifTipoInfrac(TipoInfrac seleccionada)
        {
            i = seleccionada;
            InitializeComponent();


            labelCodigo.Text = i.Cod.ToString();
            textBoxNombre.Text = i.Desc;
            labelGravedad.Text = i.Gravedad;
            textBoxImporte.Text = i.Precio.ToString();

        }


        public TipoInfrac InfraccionModificada
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
                if ((textBoxNombre.Text).Length == 0)
                    throw new BlancoException();

                i.Desc = textBoxNombre.Text;

                if (comboBoxGravedad.SelectedIndex == -1) //desplegable
                    throw new NoSeleccion();

                i.Gravedad = (String)comboBoxGravedad.SelectedItem;
                i.Precio = double.Parse(textBoxImporte.Text);

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
