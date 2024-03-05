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
    public partial class FListadoMultas : Form
    {

        private List<Multa> listaMultas;
        public FListadoMultas(List <Multa> lista)
        {
            listaMultas = lista;
            InitializeComponent();
            listBoxMultas.DataSource = null;
            listBoxMultas.DataSource = listaMultas;
            listBoxMultas.ClearSelected();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
