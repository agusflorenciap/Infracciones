using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    
    public class TipoInfrac
    {
        

        private int cod;
        private string desc;
        private string gravedad;
        private double precio;


        public TipoInfrac (int c, string d, string grav, double p)
        {
            cod = c;
            desc = d;
            gravedad = grav;
            precio = p;

        }

        public ArrayList pasarseARelacional()
        {
            ArrayList datos = new ArrayList();
            datos.Add(cod);
            datos.Add(desc);
            datos.Add(gravedad);
            datos.Add(precio);
            return (datos);
        }
        public override string ToString()
        {
            return "Código: "+ cod + " | Descripción: "+ desc + " | Gravedad: " + gravedad + " | Precio: $ " + precio;
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

        public string Gravedad
        {
            set { gravedad = value; }
            get { return gravedad; }
        }

        public double Precio
        {
            set { precio = value; }
            get { return precio; }
        }
    }
}
