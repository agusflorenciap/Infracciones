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
    public partial class FListadoPagos : Form
    {

        private List<OrdenPago> listaPagos;
        public FListadoPagos(List <OrdenPago> lista)
        {
            listaPagos = lista;
            InitializeComponent();
            listBoxPagos.DataSource = null;
            listBoxPagos.DataSource = listaPagos;
            listBoxPagos.ClearSelected();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
