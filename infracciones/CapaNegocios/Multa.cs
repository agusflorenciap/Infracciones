using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
   
    public class Multa
    {
        private int cod;
        private string numPatente;
        private string desc;
        private TipoInfrac tipoInfraccion;
        private double importe;
        private DateTime fechaCreacion;
        private DateTime fechaVenci;
        private bool pagada;

        private static double desc20diasAntesLeve = 0.25; //25%
        private static double desc10diasAntesLeve = 0.15; //15%
        private static double desc25diasAntesGrave = 0.20; //20%
        private static double recargoVencimiento = 0.15; //15% de recargo ((regla de negocio mía)



        public Multa (int c, string n, string d, TipoInfrac tipoI, double imp, DateTime fC, DateTime fV, bool p)
        {
            cod = c;
            numPatente = n;
            desc = d;
            tipoInfraccion = tipoI;
            importe = imp;
            fechaCreacion = fC;
            fechaVenci = fV;
            pagada = p;
        }

        public string mensajePagada ()
        {
            string msj;

            if (pagada)
                msj = "SÍ";
            else
                msj = "NO";

            return (msj);
        }
        public override string ToString()
        {
            return "Cod: " + cod + " | Patente: " + numPatente + " | Fecha E.: " + fechaCreacion + " | Fecha V.: " + fechaVenci + " | PAGA: " +this.mensajePagada();
        }

        public int Cod
        {
            set { cod = value; }
            get { return cod; }

        }

        public string Desc
        {
            set { desc = value; }
            get { return desc; }

        }

        public DateTime FechaCreacion
        {
            set { fechaCreacion = value; }
            get { return fechaCreacion; }
        }

        public DateTime FechaVencimiento
        {
            set { fechaVenci = value; }
            get { return fechaVenci; }
        }

        public double Importe
        {
            set { importe = value; }
            get { return importe; }
        }
        public bool Pagada
        {
            set { pagada = value; }
            get { return pagada; }
        }

        public ArrayList pasarseARelacional()
        {
            ArrayList datos = new ArrayList();
            datos.Add(cod);
            datos.Add(numPatente);
            datos.Add(desc);
            //datos.Add(tipoInfraccion) tabla de relación
            datos.Add(importe);
            datos.Add(fechaCreacion);
            datos.Add(fechaVenci);
            datos.Add(pagada);


            return (datos);
        }

        public void asignateTipoMulta (TipoInfrac infraccion)
        {
            tipoInfraccion = infraccion;
        }

        public string decimeGravedad ()
        {
            return (tipoInfraccion.Gravedad);
        }

        public double dameImporteNeto ()
        {
            double neto=0;
            DateTime hoy = DateTime.Today;

            if (hoy > fechaVenci) //vencida
                neto = importe + importe * recargoVencimiento;
            else //está en fecha. puede haber descuentos
            {
               if (decimeGravedad()=="Leve")
                {
                    if (fechaVenci.AddDays(-20)>=hoy) //está pagando 20 días antes del vencimiento
                        neto = importe - importe * desc20diasAntesLeve;
                    else
                    {
                        if (fechaVenci.AddDays(-10) >= hoy) //está pagando 10 días antes del vencimiento
                            neto = importe - importe * desc10diasAntesLeve;

                        else //no hay descuentos
                            neto = importe;
                    }
                }
               else //es grave
                {
                    if (fechaVenci.AddDays(-25) >= hoy)
                        neto = importe - importe * desc25diasAntesGrave;

                    else // no hay descuento
                        neto = importe;
                }


            }
            return neto;
        }


    }
}
