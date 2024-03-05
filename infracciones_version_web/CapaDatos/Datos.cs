using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace CapaDatos
{
    public class Datos
    {
        private static string LugarBaseAgencia;


        private static string Str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\Debug\Persistencia\baseAgencia.mdb";
        private static OleDbConnection Con;
        private static OleDbCommand Cmd;
        private static OleDbDataAdapter Da;

        private static DataSet Ds;


        public static void PonerPathBaseAccess(string l)
        {
            //LugarBaseAgencia = l + @"\Persistencia\baseAgencia.mdb";
            LugarBaseAgencia = l;
            Datos.Str += LugarBaseAgencia;

        }

        public static bool GuardarTipoInfrac(ArrayList datos)
        {
            bool todoBien = false;
            if (datos != null && datos.Count == 4)
            {
                try
                {
                    int cod = int.Parse(datos[0].ToString());
                    string desc = datos[1].ToString();
                    string grave = datos[2].ToString();
                    double pre = double.Parse(datos[3].ToString());

                    string strCmd = "INSERT INTO Infraccion ([cod],descripcion,gravedad,precio) VALUES (" + cod + "," + "'" + desc + "'" + "," + "'" + grave + "'" + "," + pre + " )";
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                    todoBien = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }
            return (todoBien);
        }


        public static void actualizarTipoInfrac(ArrayList datos)
        {
            if (datos != null && datos.Count == 4)
            {
                try
                {

                    int cod = int.Parse(datos[0].ToString()); //con esto identifico la tupla (no cambió el código)
                    string desc = datos[1].ToString();
                    string grave = datos[2].ToString();
                    double pre = double.Parse(datos[3].ToString());


                    String strCmd = "UPDATE TipoInfrac SET descripcion = " + desc + "gravedad= " + grave + "precio= " + pre + " where [cod] = " + cod;
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }
        }
        public static List<ArrayList> RecuperarVehiculo()
        {

            ArrayList datosVeh;
            List<ArrayList> contenedorVeh = new List<ArrayList>();

            try
            {

                string strCmd = "SELECT * FROM Vehiculo ORDER BY dominio";
                Con = new OleDbConnection(Str);
                Con.Open();
                Da = new OleDbDataAdapter(strCmd, Con);
                Ds = new DataSet();
                Da.Fill(Ds);

                for (int i = 0; i < (Ds.Tables[0].Rows.Count); i++)
                {
                    datosVeh = new ArrayList();

                    datosVeh.Add(Ds.Tables[0].Rows[i].ItemArray[0].ToString()); //dom        
                    datosVeh.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString()); //desc       
                    datosVeh.Add(Ds.Tables[0].Rows[i].ItemArray[2].ToString()); //nombre del dueño
                    contenedorVeh.Add(datosVeh);
                }

                Con.Close();
                Ds.Dispose();
                Da.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return (contenedorVeh);
        }

        public static List<ArrayList> RecuperarTipoInfrac()
        {

            ArrayList datosTipoInfrac;
            List<ArrayList> contenedorTipoInfrac = new List<ArrayList>();

            try
            {

                string strCmd = "SELECT * FROM Infraccion ORDER BY cod";
                Con = new OleDbConnection(Str);
                Con.Open();
                Da = new OleDbDataAdapter(strCmd, Con);
                Ds = new DataSet();
                Da.Fill(Ds);

                for (int i = 0; i < (Ds.Tables[0].Rows.Count); i++)
                {
                    datosTipoInfrac = new ArrayList();

                    datosTipoInfrac.Add(Ds.Tables[0].Rows[i].ItemArray[0].ToString()); //cod        
                    datosTipoInfrac.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString()); //desc       
                    datosTipoInfrac.Add(Ds.Tables[0].Rows[i].ItemArray[2].ToString()); //gravedad
                    datosTipoInfrac.Add(Ds.Tables[0].Rows[i].ItemArray[3].ToString()); //precio
                    contenedorTipoInfrac.Add(datosTipoInfrac);
                }

                Con.Close();
                Ds.Dispose();
                Da.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return (contenedorTipoInfrac);
        }


        public static bool GuardarMulta(ArrayList datos)
        {
            bool todoBien = false;
            if (datos != null && datos.Count == 7)
            {
                try
                {
                    int cod = int.Parse(datos[0].ToString());
                    string dom = datos[1].ToString();
                    string desc = datos[2].ToString();
                    double imp = double.Parse(datos[3].ToString());
                    DateTime fechaEmi = DateTime.Parse(datos[4].ToString());
                    DateTime fechaVen = DateTime.Parse(datos[5].ToString());
                    bool paga = bool.Parse(datos[6].ToString());


                    string strCmd = "INSERT INTO Multa ([cod],[dominio],[desc],[importe],[fechaCrea],[fechaVenci],[pagada]) VALUES (" + cod + "," + "'" + dom + "'" + "," + "'" + desc + "'" + "," + imp + "," + "'" + fechaEmi + "'" + "," + "'" + fechaVen + "'" + "," + paga + " )";
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                    todoBien = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }
            return (todoBien);
        }

        public static List<ArrayList> RecuperarMultas()
        {

            ArrayList datosMulta;
            List<ArrayList> contenedorMultas = new List<ArrayList>();

            try
            {

                string strCmd = "SELECT * FROM Multa ORDER BY cod";
                Con = new OleDbConnection(Str);
                Con.Open();
                Da = new OleDbDataAdapter(strCmd, Con);
                Ds = new DataSet();
                Da.Fill(Ds);

                for (int i = 0; i < (Ds.Tables[0].Rows.Count); i++)
                {
                    datosMulta = new ArrayList();

                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[0].ToString()); //cod        
                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString()); //dominio       
                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[2].ToString()); //desc
                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[3].ToString()); //importe
                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[4].ToString()); //fecha creacion        
                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[5].ToString()); //fecha venci     
                    datosMulta.Add(Ds.Tables[0].Rows[i].ItemArray[6].ToString()); //pagada
                    contenedorMultas.Add(datosMulta);
                }

                Con.Close();
                Ds.Dispose();
                Da.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return (contenedorMultas);
        }

        public static void actualizarMulta(ArrayList datos)
        {
            if (datos != null && datos.Count == 7)
            {
                try
                {

                    int cod = int.Parse(datos[0].ToString()); //con esto identifico la tupla (no cambió el código)
                    bool paga = true;


                    String strCmd = "UPDATE Multa SET pagada = " + paga +" where [cod] = " + cod;
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }
        }
        public static void GuardarMulta_TipoInfrac(ArrayList datos)
        {
            if (datos != null && datos.Count == 2)
            {
                try
                {
                    int codInf = int.Parse(datos[0].ToString());
                    int codMulta = int.Parse(datos[1].ToString());

                    string strCmd = "INSERT INTO Multa_TipoInfrac ([codTipoInfrac],[codMulta]) VALUES (" + codInf + "," + codMulta + ")";
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }

        }
        public static List<ArrayList> RecuperarMulta_TipoInfrac()
        {

            ArrayList datos;
            List<ArrayList> contenedorTabla = new List<ArrayList>();

            try
            {

                string strCmd = "SELECT * FROM Multa_TipoInfrac ORDER BY codMulta";
                Con = new OleDbConnection(Str);
                Con.Open();
                Da = new OleDbDataAdapter(strCmd, Con);
                Ds = new DataSet();
                Da.Fill(Ds);

                for (int i = 0; i < (Ds.Tables[0].Rows.Count); i++)
                {
                    datos = new ArrayList();

                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[0].ToString()); //cod de Tipo de Infracción         
                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString()); //cod de Multa    
                    contenedorTabla.Add(datos);
                }
                Con.Close();
                Ds.Dispose();
                Da.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return (contenedorTabla);
        }

        public static void GuardarEnTablaMultas_Vehiculo(ArrayList datos)
        {
            if (datos != null && datos.Count == 2)
            {
                try
                {
                    string dom = datos[0].ToString();
                    int codMulta = int.Parse(datos[1].ToString());

                    string strCmd = "INSERT INTO Multas_Vehiculo ([dominio],[codMulta]) VALUES (" + "'" + dom + "'" + "," + codMulta + ")";
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }

        }
        public static List<ArrayList> RecuperarMultas_Vehiculo()
        {

            ArrayList datos;
            List<ArrayList> contenedorTabla = new List<ArrayList>();

            try
            {

                string strCmd = "SELECT * FROM Multas_Vehiculo ORDER BY dominio";
                Con = new OleDbConnection(Str);
                Con.Open();
                Da = new OleDbDataAdapter(strCmd, Con);
                Ds = new DataSet();
                Da.Fill(Ds);

                for (int i = 0; i < (Ds.Tables[0].Rows.Count); i++)
                {
                    datos = new ArrayList();

                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[0].ToString()); //dominio         
                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString()); //cod de Multa    
                    contenedorTabla.Add(datos);
                }
                Con.Close();
                Ds.Dispose();
                Da.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return (contenedorTabla);
        }


        public static bool GuardarOrdenPago(ArrayList datos)
        {
            bool todoBien = false;
            if (datos != null && datos.Count == 3)
            {
                try
                {

                    int idMulta = int.Parse(datos[0].ToString());
                    double importe = double.Parse(datos[1].ToString());
                    DateTime fechaP = DateTime.Parse(datos[2].ToString());

                    string strCmd = "INSERT INTO Pago ([codMulta],[importe],[fechaPago]) VALUES (" + idMulta + "," + importe + "," + "'" + fechaP + "'" + ")";
                    Con = new OleDbConnection(Str);
                    Con.Open();
                    Cmd = new OleDbCommand(strCmd, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    Cmd.Dispose();
                    todoBien = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                }
            }
            return (todoBien);
        }

        public static List<ArrayList> RecuperarPagos()
        {

            ArrayList datos;
            List<ArrayList> contenedorTabla = new List<ArrayList>();

            try
            {

                string strCmd = "SELECT * FROM Pago ORDER BY codMulta";
                Con = new OleDbConnection(Str);
                Con.Open();
                Da = new OleDbDataAdapter(strCmd, Con);
                Ds = new DataSet();
                Da.Fill(Ds);

                for (int i = 0; i < (Ds.Tables[0].Rows.Count); i++)
                {
                    datos = new ArrayList();

                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[0].ToString()); //codMulta         
                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString()); //importe  
                    datos.Add(Ds.Tables[0].Rows[i].ItemArray[2].ToString()); //fecha
                    contenedorTabla.Add(datos);
                }
                Con.Close();
                Ds.Dispose();
                Da.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return (contenedorTabla);
        }
    }
}
