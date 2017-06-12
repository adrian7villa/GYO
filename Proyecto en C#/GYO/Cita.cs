using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYO
{
    public partial class Cita : Form
    {
        public Cita()
        {
            InitializeComponent();
        }
        public Cita(string us, string nom, string tip,string idpac,DateTime fec, string TMov)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = us;
            LTipo.Text = tip;
            TipoMov = TMov;
            idpaciente = idpac;
            fecha = fec;
            LFecha.Text = fec.ToLongDateString().ToUpper();
        }
        public Cita(string us, string nom, string tip,DateTime fec, string TMov)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = us;
            LTipo.Text = tip;
            TipoMov = TMov;
            fecha = fec;
            LFecha.Text = fec.ToLongDateString().ToUpper();
        }
        //DELEGADO
        private void PonerTexto(string c)
        {
            confirmacion = c;
        }
        private void PonerOtro(string c)
        {
            observacion = c;
        }
        private void PonerPaciente(string c)
        {
            idpaciente = c;
        }
        private void PonerMotivo(string c)
        {
            motivo = c;
        }
        //DELEGADOS
        public delegate void pasar(string dato);
        public event pasar pasado;
        //VARIABLES
        string usuario, TipoMov,rfcmedico,idpaciente="", confirmacion = "mal", observacion = "",motivo;
        DataTable TablaC=new DataTable(),THorario,TablaM,TablaME,TablaPs,TablaP;
        Conexion con = new Conexion();
        int r = 0,ndia;
        DateTime hoy = new DateTime(),fecha;
        //FUNCIONES
        public string optenerip()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public void cargarespacios()
        {
            int ntu = 0;
            THorario = con.Ejecutar_Consulta("SELECT * FROM `horario` h WHERE '" + fecha.Year + "/"
                            + fecha.Month + "/" + fecha.Day + "' BETWEEN h.`Del` AND h.`Al` ORDER BY `Entrada`", "gyo","Error al consultar horario agregar espcios");
            if(THorario.Rows.Count>0)
            {
                
                for (int i = 0; i < THorario.Rows.Count; i++)
                {
                    DateTime HEnt=DateTime.Parse(THorario.Rows[i]["Entrada"].ToString());
                    DateTime HSal = DateTime.Parse(THorario.Rows[i]["Salida"].ToString());
                    do
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Violet;
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Turno"].Value = ntu + 1;
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Horario"].Value = HEnt.ToShortTimeString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "AGENDAR";
                        HEnt=HEnt.AddMinutes(30);
                        ntu++;
                    } while (HEnt <= HSal);
                }
            }
        }
        public void quitarespacios()
        {
            TablaC = con.Ejecutar_Consulta("SELECT * FROM `cita` WHERE `Fecha`='"+fecha.Year.ToString()+"/"+fecha.Month.ToString()+"/"+fecha.Day.ToString()+"'", "gyo", "Error Al Cargar Citas");
            if(TablaC.Rows.Count>0)
            {
                for (int i = 0; i < TablaC.Rows.Count; i++)
                {
                    for (int j=0;j<dataGridView1.Rows.Count;j++)
                    {
                        if(TablaC.Rows[i]["Turno"].ToString().Equals(dataGridView1.Rows[j].Cells["Turno"].Value.ToString()) /*|| DateTime.Parse(dataGridView1.Rows[j].Cells["Horario"].Value.ToString())==DateTime.Parse( TablaC.Rows[j]["Horario"].ToString())*/)
                        {
                            //dataGridView1.Rows[j].Visible = false;
                            TablaPs = con.Ejecutar_Consulta("SELECT `ApellidoP`,`ApellidoM`,`Nombre` FROM `paciente` WHERE `id_Paciente`='"
                                                + TablaC.Rows[i]["Paciente"].ToString() 
                                                + "';", "gyo", "Error al cargar pacientes citados");
                            if(TablaPs.Rows.Count>0)
                            {
                                string nom = TablaPs.Rows[0]["ApellidoP"].ToString()
                                            +" "+ TablaPs.Rows[0]["ApellidoM"].ToString() +" "+ TablaPs.Rows[0]["Nombre"].ToString();
                                dataGridView1.Rows[j].Cells["Paciente"].Value = nom;
                                dataGridView1.Rows[j].Cells[0].Value = "CANCELAR";
                                dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                                dataGridView1.Rows[j].Cells["Usu"].Value = con.Ejecutar_Consulta("SELECT Nombre FROM usuario WHERE Usuario='" + TablaC.Rows[i]["Usuario"].ToString() + "';", "gyo", "Error btn al selecionar usuarios").Rows[0]["Nombre"].ToString();
                                dataGridView1.Rows[j].Cells["Fec_Reg"].Value = TablaC.Rows[i]["Registro"].ToString();
                            }
                            else
                            {
                                dataGridView1.Rows[j].Cells["Paciente"].Value = TablaC.Rows[i]["Paciente"].ToString();
                                dataGridView1.Rows[j].Cells[2].Value = "CANCELAR";
                                dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                                dataGridView1.Rows[j].Cells["Usu"].Value = con.Ejecutar_Consulta("SELECT Nombre FROM usuario WHERE No_Empleado=" + TablaC.Rows[i]["Usuario"].ToString() + ";", "gyo", "Error btn al selecionar usuarios").Rows[0]["Nombre"].ToString();
                                dataGridView1.Rows[j].Cells["Fec_Reg"].Value = TablaC.Rows[i]["Registro"].ToString();

                            }
                        }
                    }
                }
            }
        }
        public void cancelarcita(DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < TablaC.Rows.Count; i++)
            {
                if (TablaC.Rows[i]["Turno"].ToString().Equals(dataGridView1.Rows[e.RowIndex].Cells["Turno"].Value.ToString()))
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Esta Seguro Que Desea Eliminar La Cita?\nPaciente: " + LNombrePac.Text
                                          + "\nFecha: " + fecha.ToShortDateString()
                                          + "\nHorario: " + dataGridView1.Rows[e.RowIndex].Cells["Horario"].Value.ToString(), "Agendar", MessageBoxButtons.YesNo);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            Confirmacion CF = new Confirmacion(usuario, LNombre.Text);
                            CF.pasado += new Confirmacion.pasar(PonerTexto);
                            CF.ShowDialog();
                            if (confirmacion.Equals("bien"))
                            {
                                hoy = DateTime.Parse(con.Ejecutar_Consulta("select now();", "gyo", "Error al obtener fecha").Rows[0][0].ToString());
                                Nuevo_Elemento NE = new Nuevo_Elemento("Observacion:","txt");
                                NE.Text = "Observacion";
                                NE.pasado += new Nuevo_Elemento.pasar(PonerOtro);
                                NE.ShowDialog();

                                int nf = dataGridView1.CurrentCell.RowIndex;
                                r = con.Ejecutar_Accion("INSERT INTO `cita_cancelada` SELECT * FROM cita WHERE `id_Cita`='" + TablaC.Rows[i]["id_Cita"].ToString() + "';", "gyo", "Error al cancelar cita");
                                if (r > 0)
                                {
                                    MessageBox.Show("Cancelado");
                                    //Modificar Obs ingresar la fr
                                    //REGISTRO DE MOVIMIENTO
                                    con.Ejecutar_Accion("UPDATE `cita_cancelada` SET `Observaciones`='Cancelado Por Usuario " + LNombre.Text
                                        + " el " + DateTime.Parse(con.Ejecutar_Consulta("select now()", "hgbdracr_ce", "Error al obtener fecha").Rows[0][0].ToString())
                                        + " " + optenerip() + " " + observacion + "' WHERE `id_Cita`='" + TablaC.Rows[i]["id_Cita"].ToString() + "'", "gyo", "Error al modificar observacion");
                                    con.Ejecutar_Accion("DELETE FROM cita WHERE `id_Cita`='" + TablaC.Rows[i]["id_Cita"].ToString() + "';", "gyo", "Error al borrar citas en cancelar cita");
                                    con.Ejecutar_Accion("INSERT INTO Movimientos (`id`, `Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                               + " VALUES (NULL, '" + usuario + "', 'cita_cancelada', 'Alta De cita', '" + TablaC.Rows[i]["id_Cita"].ToString() + "', '" + hoy + "');"
                                                               , "gyo", "Error En movimientos alta histo libreta");
                                    con.Ejecutar_Accion("INSERT INTO Movimientos (`id`, `Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                               + " VALUES (NULL, '" + usuario + "', 'cita', 'Baja De cita', '" + TablaC.Rows[i]["id_Cita"].ToString() + "', '" + hoy + "');"
                                                               , "gyo", "Error En Movimientos baja de incidencia");
                                }
                                this.Close();
                            }
                            else { MessageBox.Show("La contraseña no es valida \nno esta autorizado a dar de alta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
            }


        }
        public void altacitarapida(DataGridViewCellEventArgs e)
        {
            Nuevo_Elemento nele = new Nuevo_Elemento("Motivo","combo");
            nele.Text = "Motivo";
            nele.pasado += new Nuevo_Elemento.pasar(PonerMotivo);
            nele.ShowDialog();

            DialogResult result;
            result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nDoctor: " + LMedico.Text
                                  + "\nPaciente: " + LNombrePac.Text
                                  + "\nFecha: " + fecha.ToShortDateString()
                                  + "\nTurno: " + dataGridView1.Rows[e.RowIndex].Cells["Turno"].Value.ToString(), "Agendar", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    Confirmacion CF = new Confirmacion(usuario, LNombre.Text);
                    CF.pasado += new Confirmacion.pasar(PonerTexto);
                    CF.ShowDialog();
                    if (confirmacion.Equals("bien"))
                    {
                        hoy = DateTime.Parse(con.Ejecutar_Consulta("select now();", "gyo", "Error al obtener fecha").Rows[0][0].ToString());
                        //Agregar el campo diagnostico
                        string consulta = "INSERT INTO `cita`(`id_Cita`, `Paciente`, `Fecha`, `Horario`, `Turno`"
                                            +", `Usuario`, `Registro`, `Motivo`"
                                            +") VALUES ('" 
                                            + idpaciente + hoy.Year + hoy.Month + hoy.Day + hoy.Hour + hoy.Minute + hoy.Second
                                            + "','" + idpaciente
                                            + "','" + fecha.Year + "/" + fecha.Month + "/" + fecha.Day
                                            + "','" + dataGridView1.Rows[e.RowIndex].Cells["Horario"].Value.ToString()
                                            + "','" + dataGridView1.Rows[e.RowIndex].Cells["Turno"].Value.ToString()
                                            + "','" + usuario
                                            + "','" + hoy.Year.ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Day.ToString() + " " + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ":" + hoy.Second.ToString()
                                            + "','" +motivo + "');";
                        r = con.Ejecutar_Accion(consulta, "gyo", "Error En btnAceptar->Alta->Insertar Valores En Citas");

                        if (r > 0)
                        {
                            MessageBox.Show("Guardado", "Alta");
                            //Registrar movimiento
                            string fechamov = hoy.Year + "/" + hoy.Month + "/" + hoy.Day + " " + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second;
                            con.Ejecutar_Accion("INSERT INTO `movimientos`(`Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                       + " VALUES ('" + usuario + "','Citas', 'Alta De Cita','" + idpaciente + " " + fecha.ToShortDateString() + "', '" + fechamov + " " + optenerip() + "');"
                                                       , "gyo", "Error En btnAceptar->Alta->Insertar Valores En Movimientos");
                            pasado("Citado");
                        }
                        this.Close();
                    }
                    else { MessageBox.Show("La contraseña no es valida \nno esta autorizado a dar de alta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
            //altacitapaciente(e, idpaciente);
        }
        public void altacitapaciente(DataGridViewCellEventArgs e ,string paciente)
        {
            TablaP = con.Ejecutar_Consulta("SELECT `ApellidoP`,`ApellidoM`,`Nombre` FROM `paciente` WHERE `id_Paciente`='"+paciente+"';","gyo","Error al cargar paciente nombre");
            if(TablaP.Rows.Count>0)
            {
                DialogResult result;
                result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nPaciente: " + TablaP.Rows[0]["ApellidoP"].ToString() + " " + TablaP.Rows[0]["ApellidoM"].ToString() + " " + TablaP.Rows[0]["Nombre"].ToString()
                                      + "\nFecha: " + fecha.ToShortDateString()
                                      + "\nHorario: " + dataGridView1.Rows[e.RowIndex].Cells["Horario"].Value.ToString(), "Agendar", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        Confirmacion CF = new Confirmacion(usuario, LNombre.Text);
                        CF.pasado += new Confirmacion.pasar(PonerTexto);
                        CF.ShowDialog();
                        if (confirmacion.Equals("bien"))
                        {
                            hoy = DateTime.Parse(con.Ejecutar_Consulta("select now();", "gyo", "Error al obtener fecha").Rows[0][0].ToString());
                            string consulta = "INSERT INTO `citas`(`id_Cita`,`Paciente`"
                                                + ", `Usuario`, `Fecha`"
                                                + ", `Turno`,`Registro`) VALUES ('" + idpaciente + hoy.Year + hoy.Month + hoy.Day + hoy.Hour + hoy.Minute + hoy.Second
                                                + "','" + idpaciente + "','" + usuario
                                                + "','" + fecha.Year + "/" + fecha.Month + "/" + fecha.Day
                                                + "','" + dataGridView1.Rows[e.RowIndex].Cells["Turno"].Value.ToString()
                                                + "','" + hoy.Year.ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Day.ToString() + " " + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ":" + hoy.Second.ToString() + "');";
                            r = con.Ejecutar_Accion(consulta, "gyo", "Error En btnAceptar->Alta->Insertar Valores En Citas");

                            if (r > 0)
                            {
                                MessageBox.Show("Guardado", "Alta");
                                //Registrar movimiento
                                string fechamov = hoy.Year + "/" + hoy.Month + "/" + hoy.Day + " " + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second;
                                con.Ejecutar_Accion("INSERT INTO `movimientos`(`Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                           + " VALUES ('" + usuario + "','Citas', 'Alta De Cita','" + idpaciente + " " + fecha.ToShortDateString() + " " + rfcmedico + "', '" + fechamov + "');"
                                                           , "gyo", "Error En btnAceptar->Alta->Insertar Valores En Movimientos");
                                pasado("Citado");
                            }
                            this.Close();
                        }
                        else { MessageBox.Show("La contraseña no es valida \nno esta autorizado a dar de alta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            
        }
        //EVENTOS
        private void Cita_Load(object sender, EventArgs e)
        {
            TablaP = con.Ejecutar_Consulta("SELECT ApellidoP,ApellidoM,Nombre FROM paciente WHERE id_Paciente='" + idpaciente + "';"
                            , "gyo", "Error En Load Buscar Pacinete CE");
            if (TablaP.Rows.Count > 0)
            {
                LNombrePac.Text = "Paciente: "+TablaP.Rows[0]["ApellidoP"].ToString() + " " + TablaP.Rows[0]["ApellidoM"].ToString() + " " + TablaP.Rows[0]["Nombre"].ToString();
            }
            cargarespacios();
            quitarespacios();
            /*for(int i=0;i<=23;i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Violet;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = i + 1;
                //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = 1;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "AGENDAR";
            }*/
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("CANCELAR"))
                {
                    cancelarcita(e);
                }
                else
                {
                    switch(TipoMov)
                    {
                        case "Cita":
                            altacitarapida(e);

                            break;
                        case "Paciente":
                            altacitapaciente(e,idpaciente);
                            break;
                    }
                }
            }
        }
    }
}
