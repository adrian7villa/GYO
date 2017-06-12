using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GYO
{
    class Conexion
    {
        public string CadenaConexion;
        public MySqlConnection Conex;
        MySqlDataAdapter Adaptador;
        MySqlCommandBuilder Constructor;
        //public OleDbConnection Conex;
        //public OleDbDataAdapter Adaptador;
        //public OleDbCommandBuilder Constructor;
        public DataTable TablaD;

        public DataTable Ejecutar_Consulta(String Consulta, String BaseD, string mensaje)
        {
            try
            {
                Conectar(BaseD);
                Adaptador = new MySqlDataAdapter(Consulta, Conex);
                Constructor = new MySqlCommandBuilder(Adaptador);
                //Adaptador = new OleDbDataAdapter(Consulta, Conex);
                //Constructor = new OleDbCommandBuilder(Adaptador);
                TablaD = new DataTable("Datos");
                Adaptador.Fill(TablaD);
                Desconectar();
                return TablaD;
            }
            catch (Exception exp)
            {
                string Fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                //Ejecutar_Accion("INSERT INTO Errores (Fecha,Texto) VALUES(#" + Fecha + "#,'" + mensaje + "\n\nError:" + exp + "');", BaseD, "Error En El catch");
                Error("INSERT INTO Errores (Fecha,Texto) VALUES(#" + Fecha + "#,'" + mensaje + "RX" + "\n\nError:" + exp + "');"
                    , BaseD, "Error en el catch Ejecutar_Consulta \n");
                MessageBox.Show(mensaje + "\n\nError:" + exp, "Error En La Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return TablaD;
            }
        }
        public int Ejecutar_Accion(String Consulta, String BaseD, string mensaje)
        {
            int i = 0;
            try
            {
                Conectar(BaseD);
                MySqlCommand cmd = new MySqlCommand(Consulta, Conex);
                //OleDbCommand cmd = new OleDbCommand(Consulta, Conex);
                i=cmd.ExecuteNonQuery();
                Desconectar();
                return i;
            }
            catch (Exception exp)
            {
                string Fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                //Ejecutar_Accion("INSERT INTO Errores (Fecha,Texto) VALUES(#" + Fecha + "#,'" + mensaje + "\n\nError:" + exp + "');", BaseD, "Error En El catch");
                Error("INSERT INTO Errores (Fecha,Texto) VALUES(#" + Fecha + "#,'" + mensaje+"RX" + "\n\nError:" + exp + "');"
                    , BaseD, "Error en el catch Ejecutar_Accion \n");
                MessageBox.Show(mensaje + "\n\nError:" + exp, "Error En La Accion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return i;
            }
        }
        public void Error(String Consulta, String BaseD, string mensaje)
        {
            try
            {
                Conectar(BaseD);
                MySqlCommand cmd = new MySqlCommand(Consulta, Conex);
                //OleDbCommand cmd = new OleDbCommand(Consulta, Conex);
                cmd.ExecuteNonQuery();
                Desconectar();
            }
            catch (Exception exp)
            {                
                MessageBox.Show(mensaje+exp);
            }
        }


        public void Conectar(string bd)
        {
            //Lap Adrian con password 1234567890 local
            //CadenaConexion = "SERVER=localhost;PORT=3306;UID=Adrian;PWD=H1802120100*;DATABASE="+bd+ ";Convert Zero Datetime=True;Allow Zero Datetime=True;";
            //PC Dra
            CadenaConexion = "SERVER=localhost;PORT=3306;UID=root;PWD=;DATABASE=" + bd + ";Convert Zero Datetime=True;Allow Zero Datetime=True;";
            Conex = new MySqlConnection(CadenaConexion);
            Conex.Open();//se abre la conexion
        }
        public void Desconectar()
        {
            Conex.Close();
        }
        public string url(string carpeta)
        {
            //Jose Luis
            //string url = @"\\02NLMR\Sistema\FormatosRX\";
            //string url = @"C:\Sistema\FormatosCE"+carpeta+@"\";
            //string url = @"\\02NLMR\Sistema\FormatosRX\";
            //string url = @"C:\Sistema\FormatosRX\";

            //string url = @"\\02NLMR\Sistema\" + carpeta + @"\";
            //string url = @"\\2707_02NFFX\SRX\" + carpeta + @"\";
            string url = @"C:\Formatos\" + carpeta + @"\";
            return url;
        }
    }
}
