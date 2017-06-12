using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace GYO
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //VARIABLES
        Conexion con = new Conexion();
        DataTable TablaU;
        //EVENTOS
        //BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 0 && txtContraseña.Text.Length > 0)
            {
                TablaU=con.Ejecutar_Consulta("SELECT * FROM `usuario` WHERE `Usuario`='" + txtUsuario.Text + "';", "gyo","Error btn al selecionar usuarios");
                if (TablaU.Rows.Count > 0)
                {
                    if (TablaU.Rows[0]["Activo"].ToString().Equals("1") || TablaU.Rows[0]["Activo"].ToString().Equals("True"))
                    {
                        if (TablaU.Rows[0]["Usuario"].ToString().Equals(txtUsuario.Text))
                        {
                            if (TablaU.Rows[0]["Password"].ToString().Equals(txtContraseña.Text))
                            {
                                //Invocar Ventana
                                this.Hide();
                                Form1 formaP = new Form1(TablaU.Rows[0]["Usuario"].ToString(), TablaU.Rows[0]["Nombre"].ToString(), TablaU.Rows[0]["Tipo"].ToString());
                                formaP.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("La Contraseña no coincide revisela");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Usuario no coincide reviselo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no activo");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }
            }
            else
            {
                MessageBox.Show("Llene todos los datos");
            }
        }
    }
}
