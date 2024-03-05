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
    public partial class FListadoTipoInfrac : Form
    {

        private List<TipoInfrac> listaTipo;
        public FListadoTipoInfrac(List <TipoInfrac> lista)
        {
            listaTipo = lista;
            InitializeComponent();
            listBoxTipos.DataSource = null;
            listBoxTipos.DataSource = listaTipo;
            listBoxTipos.ClearSelected();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
