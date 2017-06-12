using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYO
{
    public partial class AltaRapida : Form
    {
        public AltaRapida()
        {
            InitializeComponent();
        }
        public AltaRapida(string us, string nom, string tipo)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = us;
            LTipo.Text = tipo;
        }
        //DELEGADOS
        public delegate void pasar(string dato);
        public event pasar pasado;
        //DELEGADOS
        //   Locales
        private void PonerTexto(string c)
        {
            confirmacion = c;
        }
        //VARIABLES
        Conexion con = new Conexion();
        DataTable TablaD;
        string usuario, confirmacion = "mal";
        DateTime hoy = new DateTime();
        int r = 0;
        //FUNCIONES
        //BOTONES
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TablaD = con.Ejecutar_Consulta("SELECT * FROM `paciente` WHERE (`ApellidoP`='"+txtApellidoP.Text+"' AND `ApellidoM`='"+txtApellidoM.Text+"' AND `Nombre`='"+txtNombre.Text
                            +"') OR `Tel_Cel`='"+txtTel_Celular.Text+"';", "gyo", "error al consultar al paciente si existe");
            if(TablaD.Rows.Count==0)
            {
                if (!txtApellidoP.Text.Equals(""))
                {
                    if (!txtNombre.Text.Equals(""))
                    {
                        if (!txtTel_Celular.Text.Equals(""))
                        {
                            DialogResult result;
                            result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nNombre: " + txtApellidoP.Text + " "
                                     + txtApellidoM.Text + " " + txtNombre.Text + "\nCelular: " + txtTel_Celular.Text, "Aceptar", MessageBoxButtons.YesNo);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    Confirmacion CF = new Confirmacion(usuario, LNombre.Text);
                                    CF.pasado += new Confirmacion.pasar(PonerTexto);
                                    CF.ShowDialog();
                                    if (confirmacion.Equals("bien"))
                                    {
                                        //String RFC = txtRFC.Text + CBTipo.Text.Substring(0, 2) + repetido;
                                        string Fecha = hoy.Year.ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Day.ToString();
                                        string id = txtApellidoP.Text.Substring(0, 1) + txtNombre.Text.Substring(0, 1) + hoy.Year + hoy.Month + hoy.Day + hoy.Day + hoy.Hour + hoy.Minute + hoy.Second;
                                        //Da De Alta al paciente
                                        r = con.Ejecutar_Accion("INSERT INTO `paciente`(`id_Paciente`, `ApellidoP`, `ApellidoM`, `Nombre`, `Tel_Casa`, `Observaciones`)" +
                                            " VALUES ('" + id + "','" + txtApellidoP.Text + "','" + txtApellidoM.Text + "','" + txtNombre.Text + "','" + txtTel_Celular.Text
                                            + "','" + RTBObservaciones.Text.ToUpper() + "');"
                                                      , "gyo", "Error En btnAceptar->Insertar Paciente");
                                        if (r > 0)
                                        {
                                            //Registrar movimiento
                                            Fecha = Fecha + " " + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ":" + hoy.Second.ToString();
                                            con.Ejecutar_Accion("INSERT INTO movimientos (`Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                           + " VALUES ('" + usuario + "', 'Paciente','Alta Paciente','Paciente id=" + id + " Nombre=" + txtApellidoP.Text + txtApellidoM.Text + "', '" + Fecha + "');"
                                                           , "gyo", "Error En btnAceptar->Insertar Movimiento");


                                            MessageBox.Show("Pacinete dado de alta");
                                            Agenda agen = new Agenda(usuario, LNombre.Text, LTipo.Text, id);
                                            agen.ShowDialog();
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
                        else { MessageBox.Show("Agrege un telefono"); }
                    }
                    else { MessageBox.Show("Agrege un nombre"); }
                }
                else { MessageBox.Show("Agrege un apellido en paterno"); }
            }
            else
            {
                MessageBox.Show("El paciente ya existe haga una busqueda");
            }
        }
        //EVENTOS
        private void AltaRapida_Load(object sender, EventArgs e)
        {
            hoy = DateTime.Parse(con.Ejecutar_Consulta("select now();", "gyo", "Error al obtener fecha").Rows[0][0].ToString());
            //cargarmotivos();
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtApellidoP.CharacterCasing = CharacterCasing.Upper;
            txtApellidoM.CharacterCasing = CharacterCasing.Upper;
            txtTel_Celular.CharacterCasing = CharacterCasing.Upper;  
        }
    }
}
