using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Vehiculo
    {
        private string dominio;
        private string desc;
        private string nombDueño;
        private List<Multa> multas;

        public Vehiculo (string dom, string d, string nomb)
        {
            dominio = dom;
            desc = d;
            nombDueño = nomb;
            multas = new List<Multa>();

        }



        public override string ToString()
        {
            return "Dominio: " + dominio + " | Descripción: " + desc + " | Nombre Dueño: " + nombDueño + " | Cant. Multas Total: " + multas.Count();
        }



        public string Dominio
        {
            set { dominio = value; }
            get { return dominio; }

        }

        public string Desc
        {
            set { desc = value; }
            get { return desc; }
        }

        public string NombDueño
        {
            set { nombDueño = value; }
            get { return nombDueño; }
        }

        public List<Multa> ListaMultas
        {
            get { return multas; }
        }


        public void sumateMulta (Multa m)
        {
            multas.Add(m);
        }
    }
}
