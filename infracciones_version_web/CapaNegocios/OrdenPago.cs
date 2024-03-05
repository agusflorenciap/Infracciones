using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class OrdenPago
    {
        private int idMulta;
        private double importe;
        private DateTime fechaPago;



        public OrdenPago (int codMulta, double imp, DateTime f)
        {
            idMulta = codMulta;
            importe = imp;
            fechaPago = f;
        }

        public int Cod
        {
            set { idMulta = value; }
            get { return idMulta; }

        }

        public double Imp
        {
            set { importe = value; }
            get { return importe; }

        }

        public DateTime Fecha
        {
            set { fechaPago = value; }
            get { return fechaPago; }

        }

        public override string ToString()
        {
            return "Cód de Multa: " + idMulta + " | Importe: " + importe + " | Fecha de Pago: " + fechaPago;
        }

        public ArrayList pasarseARelacional()
        {
            ArrayList datos = new ArrayList();
            datos.Add(idMulta);
            datos.Add(importe);
            datos.Add(fechaPago);


            return (datos);
        }



    }
}
