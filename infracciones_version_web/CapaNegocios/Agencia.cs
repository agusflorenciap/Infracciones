using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class Agencia
    {
        private List<Multa> multas;
        private List<TipoInfrac> tiposDeInfracciones;
        private List<Vehiculo> vehiculos;
        private List<OrdenPago> pagos;

        public Agencia()
        {
            multas = new List<Multa>();
            tiposDeInfracciones = new List<TipoInfrac>();
            vehiculos = new List<Vehiculo>();
            pagos = new List<OrdenPago>();


          this.recuperarTiposDeInfracciones();
          this.recuperarVehiculos();
          this.recuperarMultas();
          this.recuperarMulta_TipoInfrac();
          this.recuperarMultas_Vehiculo();
          this.recuperarPagos();
        }

       public static void PonerPathABaseAccess(string l)
        {
            Datos.PonerPathBaseAccess(l);
        }
        
        public List<Multa> ListaMultas
        {
            get { return multas; }
        }

        public List<TipoInfrac> ListaTipoDeInfrac
        {
            get { return tiposDeInfracciones; }
        }

        public List<Vehiculo> ListaVehiculos
        {
            get { return vehiculos; }
        }

        public List<OrdenPago> ListaPagos
        {
            get { return pagos; }
        }

        public void registrarTipoInfrac(TipoInfrac t)
        {
           bool todoBien = false;
            if (t != null)
            {
                todoBien = Datos.GuardarTipoInfrac(t.pasarseARelacional());
               if (todoBien)
                    this.tiposDeInfracciones.Add(t);
            }

        }

        public void registrarPago(int codMulta)
        {
            bool todoBien = false;

            Multa m = this.buscameMulta(codMulta);


            if (m != null)
            {


                double importeNeto = m.dameImporteNeto();

                OrdenPago o = new OrdenPago(codMulta, importeNeto, DateTime.Today);

                if (o != null)
                {
                    todoBien = Datos.GuardarOrdenPago(o.pasarseARelacional());
                    if (todoBien)
                        this.pagos.Add(o);
                }

                m.Pagada = true; //cambio variable bool
            }

        }

        public OrdenPago buscameOrdenParaFormulario (int codM)
        {
            int i = 0;
            OrdenPago o;

            while ((i < pagos.Count) && (codM != pagos.ElementAt(i).Cod))
                i++;

            if (i == pagos.Count) //no existe la orden
                o = null;
            else
                o = pagos.ElementAt(i);

            return (o);
        }

        public void recuperarPagos()
        {
            int codMulta;
            double imp;
            DateTime f;


            List<ArrayList> contenedorTabla = new List<ArrayList>();
            contenedorTabla = Datos.RecuperarPagos();

            ArrayList posicionActual;

            for (int i = 0; i < contenedorTabla.Count; i++)
            {
                posicionActual = new ArrayList();
                posicionActual = contenedorTabla[i];

                codMulta = int.Parse(posicionActual[0].ToString());
                imp = double.Parse(posicionActual[1].ToString());
                f = DateTime.Parse(posicionActual[2].ToString());


                OrdenPago o = new OrdenPago(codMulta, imp, f);
                pagos.Add(o);
            }
        }

        

        public void recuperarVehiculos()
        {
            Vehiculo v = null;

            string dominio;
            string desc;
            string nombDueño;

            List<ArrayList> contenedorVehiculos = new List<ArrayList>();
            contenedorVehiculos = Datos.RecuperarVehiculo();

            ArrayList posicionActual;

            for (int i = 0; i < contenedorVehiculos.Count; i++)
            {
                posicionActual = new ArrayList();
                posicionActual = contenedorVehiculos[i];

                dominio = posicionActual[0].ToString();
                desc = posicionActual[1].ToString();
                nombDueño = posicionActual[2].ToString();

                v = new Vehiculo(dominio, desc, nombDueño);

                vehiculos.Add(v);
            }

        }

        public Vehiculo buscameVehiculo (string dom)
        {
            int i = 0;
            Vehiculo v;

            while ((i < vehiculos.Count) && (dom != vehiculos.ElementAt(i).Dominio))
                i++;

            if (i == vehiculos.Count) //no existe el veh
                v = null;
            else
                v = vehiculos.ElementAt(i);

            return (v);

        }


        public void actualizarTipoInfrac(TipoInfrac t)
        {
            if (t != null)
            {
                Datos.actualizarTipoInfrac(t.pasarseARelacional());
            }
        }

        public void recuperarTiposDeInfracciones()
        {
            TipoInfrac inf = null;
            
            int cod;
            string desc;
            string gravedad;
            double precio;

            List<ArrayList> contenedorTipoInfrac = new List<ArrayList>();
            contenedorTipoInfrac = Datos.RecuperarTipoInfrac(); //en vez de tener un array de datos de tipodeInfrac, hacer una list de arraylist. cada posición del list es un array (con datos de un tipo de infrac)
                                                        //con cada posición creo un tipo de infraccion.

            ArrayList posicionActual;

            for (int i = 0; i < contenedorTipoInfrac.Count; i++)
            {
                posicionActual = new ArrayList();
                posicionActual = contenedorTipoInfrac[i];

                cod = int.Parse(posicionActual[0].ToString());
                desc = posicionActual[1].ToString(); //en teoría ya es tipo string pero x las dudas lo paso también
                gravedad = posicionActual[2].ToString();
                precio = double.Parse(posicionActual[3].ToString());
              
                inf = new TipoInfrac(cod,desc, gravedad, precio);

                tiposDeInfracciones.Add(inf);
            }

        }


        public void registrarMulta(Multa m)
        {
            bool todoBien = false;
            if (m != null)
            {
                todoBien = Datos.GuardarMulta(m.pasarseARelacional());
                if (todoBien)
                    this.multas.Add(m);
            }

        }
        public void recuperarMultas()
        {
            Multa m = null;

        int cod;
        string numPatente;
        string desc;
        double importe;
        DateTime fechaCreacion;
        DateTime fechaVencimiento;
        bool pagada;

        List<ArrayList> contenedorMultas = new List<ArrayList>();
            contenedorMultas = Datos.RecuperarMultas(); 

            ArrayList posicionActual;

            for (int i = 0; i < contenedorMultas.Count; i++)
            {
                posicionActual = new ArrayList();
                posicionActual = contenedorMultas[i];

                cod = int.Parse(posicionActual[0].ToString());
                numPatente = posicionActual[1].ToString(); 
                desc = posicionActual[2].ToString();
                importe = double.Parse(posicionActual[3].ToString());
                fechaCreacion = DateTime.Parse(posicionActual[4].ToString());
                fechaVencimiento = DateTime.Parse(posicionActual[5].ToString());
                pagada = bool.Parse(posicionActual[6].ToString());

                m = new Multa(cod, numPatente, desc, null, importe, fechaCreacion, fechaVencimiento, pagada);

                multas.Add(m);
            }

        }

        public void actualizarMulta(int codM)
        {
            Multa m = this.buscameMulta(codM);

            if (m != null)
            {
                Datos.actualizarMulta(m.pasarseARelacional());
            }
        }
        public void GuardarEnTablaMulta_TipoInfrac(int codTipoInfrac, int codMulta)
        {

            // tengo que crear un array con esos dos campos y se lo paso a la capa de datos
            //ahí es donde un método guardarMulta_TipoInfrac va a hacer lo mismo que los que ya hice ((hacer el insert y blabla))

            ArrayList datos = new ArrayList();
            datos.Add(codTipoInfrac);
            datos.Add(codMulta);
            Datos.GuardarMulta_TipoInfrac(datos);

        }




            public void recuperarMulta_TipoInfrac()
        {
            int codTipoInfrac;
            int codMulta;
            

            List<ArrayList> contenedorTabla = new List<ArrayList>();
            contenedorTabla = Datos.RecuperarMulta_TipoInfrac();

            ArrayList posicionActual;

            for (int i = 0; i < contenedorTabla.Count; i++)
            {
                posicionActual = new ArrayList();
                posicionActual = contenedorTabla[i];

                codTipoInfrac = int.Parse(posicionActual[0].ToString());
                codMulta = int.Parse(posicionActual[1].ToString());


                TipoInfrac inf = buscameTipoInfrac(codTipoInfrac);
                Multa m = buscameMulta(codMulta);

                if ((inf != null) && (m != null))
                    m.asignateTipoMulta(inf);
            }
        }


        public TipoInfrac buscameTipoInfrac(int cod)
        {
            int i = 0;
            TipoInfrac inf;

            while ((i < tiposDeInfracciones.Count) && (cod != tiposDeInfracciones.ElementAt(i).Cod))
                i++;

            if (i == tiposDeInfracciones.Count) //no existe el tipo de infracción
                inf = null;
            else
                inf = tiposDeInfracciones.ElementAt(i);

            return (inf);
        }

        public Multa buscameMulta(int cod)
        {
            int i = 0;
            Multa m;

            while ((i < multas.Count) && (cod != multas.ElementAt(i).Cod))
                i++;

            if (i == multas.Count) //no existe la multa
                m = null;
            else
                m = multas.ElementAt(i);

            return (m);
        }


        public void GuardarEnTablaMultas_Vehiculo(string dom, int codMulta)
        {



            ArrayList datos = new ArrayList();
            datos.Add(dom);
            datos.Add(codMulta);
            Datos.GuardarEnTablaMultas_Vehiculo(datos);

        }

        public void recuperarMultas_Vehiculo()
        {
            string dom;
            int codMulta;


            List<ArrayList> contenedorTabla = new List<ArrayList>();
            contenedorTabla = Datos.RecuperarMultas_Vehiculo();

            ArrayList posicionActual;

            for (int i = 0; i < contenedorTabla.Count; i++)
            {
                posicionActual = new ArrayList();
                posicionActual = contenedorTabla[i];

                dom = posicionActual[0].ToString();
                codMulta = int.Parse(posicionActual[1].ToString());


                Vehiculo v= buscameVehiculo(dom);
                Multa m = buscameMulta(codMulta);

                if ((v != null) && (m != null))
                    v.sumateMulta(m);
                   
            }
        }

    }
}
