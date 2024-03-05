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
    public partial class FListadoVeh : Form
    {

        private List<Vehiculo> listaVehiculos;
        public FListadoVeh (List <Vehiculo> lista)
        {
            listaVehiculos = lista;
            InitializeComponent();
            listBoxVehiculos.DataSource = null;
            listBoxVehiculos.DataSource = listaVehiculos;
            listBoxVehiculos.ClearSelected();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
