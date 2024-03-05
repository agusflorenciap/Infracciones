using CapaNegocios;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class FABMTipoInfrac : Form
    {
        private Agencia a;
        private TipoInfrac i;
        private TipoInfrac tipoInfSelec;
        public FABMTipoInfrac(Agencia agencia)
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

        private void button4_Click(object sender, EventArgs e) //agregar tipo de infrac
        {
            FAltaTipoInfrac fAgregar = new FAltaTipoInfrac();
            fAgregar.ShowDialog();

            i = fAgregar.TipoInfraccion;
            a.registrarTipoInfrac(i);

            listBoxTiposInfrac.DataSource = null;
            listBoxTiposInfrac.DataSource = a.ListaTipoDeInfrac;
            listBoxTiposInfrac.ClearSelected();
        }

        private void button3_Click(object sender, EventArgs e) //modificar tipo infrac
        {
            try
            {
                tipoInfSelec = (TipoInfrac)listBoxTiposInfrac.SelectedItem;
                if (tipoInfSelec == null)
                    throw new NoSeleccion();


                FModifTipoInfrac fModif = new FModifTipoInfrac(tipoInfSelec);
                fModif.ShowDialog();

                i = fModif.InfraccionModificada;
                a.actualizarTipoInfrac(i);
            }

            catch (NoSeleccion ex)
            {
                MessageBox.Show(ex.Message);
            }


            listBoxTiposInfrac.DataSource = null;
            listBoxTiposInfrac.DataSource = a.ListaTipoDeInfrac;
            listBoxTiposInfrac.ClearSelected();

        }
    }
}
