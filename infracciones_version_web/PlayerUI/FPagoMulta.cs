using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using Excepciones;

namespace PlayerUI
{
    public partial class FPagoMulta : Form
    {

        private Agencia a;
        private Vehiculo v;
        private OrdenPago p;
        public FPagoMulta(Agencia agencia)
        {
            a = agencia;
            InitializeComponent();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e) //siguiente
        {
            try
            {
         
                Multa m = (Multa)listBoxMultas.SelectedItem;
                if (m == null)
                    throw new NoSeleccion();

                FPagoMultaSiguiente fSiguiente = new FPagoMultaSiguiente(m);

                fSiguiente.ShowDialog();
                p = fSiguiente.OrdenGenerada;

                //a.registrarPago(p);
                //m.Pagada = true; //cambio variable bool
                //a.actualizarMulta(m); //actualizo el registro en bd

                this.Close();
            }
            catch (NoSeleccion ex)
            {
                MessageBox.Show(ex.Message);
                listBoxMultas.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string dom = textBoxDominio.Text;

                if (dom.Length==0)
                    throw new BlancoException();

                v = a.buscameVehiculo(dom);

                if (v == null)
                    throw new InexistenciaVehiculo();

                else //existe. lleno el listbox.
                {

                    label2.Visible = true;
                    listBoxMultas.Visible = true;
                    

                    List<Multa> listaOriginal = v.ListaMultas;
                   /* List<Multa> listaFiltrada = new List<Multa>();
                    int i = 0;

                    while (i <listaOriginal.Count) //recorro la lista y dejo solo a las multas que no estan pagas
                    {
                        Multa m = listaOriginal.ElementAt(i);
                        bool paga = m.Pagada;

                        if (paga)
                            listaFiltrada.Add(m);
                    }
                    listBoxMultas.DataSource = null;
                    listBoxMultas.DataSource = listaFiltrada;
                    listBoxMultas.ClearSelected();
                    */

                    listBoxMultas.DataSource = null;
                    listBoxMultas.DataSource = listaOriginal;
                    listBoxMultas.ClearSelected();
                }
            }

            catch (InexistenciaVehiculo ex)
            {
                MessageBox.Show(ex.Message);
                textBoxDominio.Focus();
            }

            catch (BlancoException ex)
            {
                MessageBox.Show(ex.Message);
                textBoxDominio.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
