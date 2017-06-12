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
    public partial class Cambio_Contra : Form
    {
        public Cambio_Contra()
        {
            InitializeComponent();
        }
        public Cambio_Contra(string us, string nom)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = LUsuario.Text=us;
        }
        //DELEGADOS
        //   Locales
        private void PonerTexto(string c)
        {
            confirmacion = c;
        }
        //VARIABLES
        Conexion con = new Conexion();
        DataTable TablaU;
        string usuario, fecha, confirmacion = "mal";
        int r = 0;
        //EVENTOS
        //BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length > 0)
            {
                if(txtConfirmacion.Text.Length>0)
                {
                    TablaU=con.Ejecutar_Consulta("SELECT * FROM usuarios WHERE No_Empleado=" + LUsuario.Text + ";", "RayoX","Error al btn selecionar usuarios");
                    if (TablaU.Rows.Count > 0)
                    {
                        if (TablaU.Rows[0]["Activo"].ToString().Equals("1"))
                        {
                            if(txtContraseña.Text.ToString().Equals(txtConfirmacion.Text.ToString()))
                            {
                                //Verificar los datos llenados
                                DialogResult result;
                                result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nContraseña: " + txtContraseña.Text, "Aceptar", MessageBoxButtons.YesNo);
                                switch (result)
                                {
                                    case DialogResult.Yes:
                                        Confirmacion CF = new Confirmacion(usuario, LNombre.Text);
                                        CF.pasado += new Confirmacion.pasar(PonerTexto);
                                        CF.ShowDialog();
                                        if (confirmacion.Equals("bien"))
                                        {
                                            r=con.Ejecutar_Accion("UPDATE Usuarios SET Contraseña = '" + txtContraseña.Text
                                          + "' WHERE No_Empleado= " + LUsuario.Text + ";"
                                          , "RayoX", "Error En btnCambiar->Modificar->Modificar contraseña");
                                            if(r>0)
                                            {
                                                MessageBox.Show("Modificado");

                                                //Registrar movimiento
                                                fecha = DateTime.Today.ToShortDateString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString(); ;
                                                con.Ejecutar_Accion("INSERT INTO Movimientos (`Usuario`, `Tipo_M`, `Fecha`)"
                                                                               + " VALUES ('" + usuario + "', 'Modificacion De Usuario " + LUsuario.Text + "," + LNombre.Text + "', '" + fecha + "');"
                                                                               , "RayoX", "Error En btnCambiar->Modificar->Insertar Valores En Movimientos");
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se logro modifcar");
                                            }
                                            this.Close();
                                        }
                                        else { MessageBox.Show("La contraseña no es valida \nno esta autorizado a cambiar contraseña", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        break;
                                    case DialogResult.No:
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("La Contraseña No Es Igual");
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
                    MessageBox.Show("Confime su contraseña");
                }
            }
            else
            {
                MessageBox.Show("Escriba su nueva contraseña");
            }
        }
    }
}
