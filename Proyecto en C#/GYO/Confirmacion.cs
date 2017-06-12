using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GYO
{
    public partial class Confirmacion : Form
    {
        public Confirmacion()
        {
            InitializeComponent();
        }
        public Confirmacion(string us,string nom)
        {
            InitializeComponent();
            nombre=LNombre.Text = nom;
            usuario = us;
        }
        //DELEGADOS
        public delegate void pasar(string dato);
        public event pasar pasado; 
        //VARIABLES
        string usuario, nombre;
        Conexion con = new Conexion();
        DataTable TablaU;
        //BOTONES
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (usuario.Length > 0 && txtContraseña.Text.Length > 0)
            {
                TablaU=con.Ejecutar_Consulta("SELECT * FROM usuario WHERE Usuario='" + usuario + "';","gyo","Error en btnAceptar->Selecionar un usuario");
                if (TablaU.Rows.Count > 0)
                {
                    if (TablaU.Rows[0]["Activo"].ToString().Equals("True") || TablaU.Rows[0]["Activo"].ToString().Equals("True"))
                    {
                        if (TablaU.Rows[0]["Usuario"].ToString().Equals(usuario))
                        {
                            if (TablaU.Rows[0]["Password"].ToString().Equals(txtContraseña.Text))
                            {
                                pasado("bien");
                                this.Close();
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
                        MessageBox.Show("Usuario no activo: ");
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

        private void Confirmacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
