using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using exel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Data.OleDb;
/*Quitar lo del folio solo dar de alta al paciente*/


namespace GYO
{
    public partial class Alta_Paciente : Form
    {
        public Alta_Paciente()
        {
            InitializeComponent();
        }
        public Alta_Paciente(string us, string nom, string tipo,string mov)
        {
            InitializeComponent();
            nombre = nom;
            usuario = us;
            Movimiento = "Alta";
            tipous = tipo;
            Movimiento = mov;
        }
        public Alta_Paciente(string us, string nom, string tip, string mov, string id)
        {
            InitializeComponent();
            nombre = nom;
            usuario = us;
            tipous = tip;
            Movimiento =mov;
            id_b = id;
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
        public void PonerPara(string rf)
        {
            //Madar para agendar con RFC
            switch(rf)
            {
                case "Cerrar":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        //VARIABLES
        Conexion con = new Conexion();
        DataTable TablaU;
        string url, nombre, usuario, confirmacion = "mal",Movimiento,rfcb,tipous,id_b;
        DateTime hoy = new DateTime();
        int r = 0;
        //FUNCIONES
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsWhiteSpace(e.KeyChar) || //Espacio
                char.IsPunctuation(e.KeyChar)) //Pontuacion
                e.Handled = true;
        }
        public void mayusculas()
        {
            //txtRFC.CharacterCasing = CharacterCasing.Upper;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtApellidoP.CharacterCasing = CharacterCasing.Upper;
            txtApellidoM.CharacterCasing = CharacterCasing.Upper;
            txtCalle.CharacterCasing = CharacterCasing.Upper;
            txtColonia.CharacterCasing = CharacterCasing.Upper;
            txtTel_Casa.CharacterCasing = CharacterCasing.Upper;
            txtTel_Celular.CharacterCasing = CharacterCasing.Upper;
            //txtTel_Familiar.CharacterCasing = CharacterCasing.Upper;
        }
        public void alta()
        {
            if (!txtApellidoM.Text.Equals("") && !txtNombre.Text.Equals(""))
            {
                if (!txtCalle.Text.Equals("") && !txtNumero.Text.Equals("") && !txtColonia.Text.Equals("") && !CBMunicipio.Text.Equals("Seleccione Una Opcion...") && !txtCP.Text.Equals(""))
                {
                    if (!txtTel_Casa.Text.Equals("") && !txtTel_Celular.Text.Equals("") && !CBMunicipio.Text.Equals("Seleccione Una Opcion..."))
                    {
                        //String RFC = txtRFC.Text.Replace(" ","");
                        try
                        {
                            DialogResult result;
                            result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nRFC: " + txtApellidoM.Text + "\nNombre: " + txtApellidoP.Text + " "
                                     + txtApellidoM.Text + " " + txtNombre.Text + "\nDomicilio: " + txtCalle.Text + " #" + txtNumero.Text + " \nCol. " + txtColonia.Text
                                     + "CP" + txtCP.Text + " Municipio: " + CBMunicipio.Text + "\n\nTELEFONOS\n\nCasa: " + txtTel_Casa.Text
                                     + "\nCelular: " + txtTel_Celular.Text + "\nClinica: "
                                     + CBMunicipio.Text, "Aceptar", MessageBoxButtons.YesNo);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    Confirmacion CF = new Confirmacion(usuario, nombre);
                                    CF.pasado += new Confirmacion.pasar(PonerTexto);
                                    CF.ShowDialog();
                                    if (confirmacion.Equals("bien"))
                                    {
                                        //String RFC = txtRFC.Text + CBTipo.Text.Substring(0, 2) + repetido;
                                        /*String Fecha = hoy.Year.ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Day.ToString();
                                        String Sexo = CBSexo.Text.Substring(0, 1);
                                        //Da De Alta al paciente
                                        r = con.Ejecutar_Accion("INSERT INTO paciente (`RFC`, `ApellidoP`, `ApellidoM`, `Nombre`, `Calle`,"
                                                      + " `No`, `Colonia`, `CP`, `Tel_Casa`, `Tel_Celular`, `Tel_Familiar`, `Municipio`, `Edad`,"
                                                      + " `Observaciones`, `Tipo`, `Fec_Ingreso`, `Sexo`, `Clinica_Procedencia`, `Activo`,`Dependencia`) VALUES ('" + RFC + "', '" + txtApellidoP.Text + "', '"
                                                      + txtApellidoM.Text + "'," + " '" + txtNombre.Text + "', '" + txtCalle.Text + "', '" + txtNumero.Text + "', '" + txtColonia.Text + "', '"
                                                      + txtCP.Text + "', '" + txtTel_Casa.Text + "', '" + txtTel_Celular.Text + "', '" + txtTel_Familiar.Text + "', '" + CBMunicipio.Text + "'"
                                                      + ", '" + DTPFecNac.Value.Year + "', '" + RTBObservaciones.Text + "', '" + Tipo + "', '" + Fecha + "','" + Sexo + "','" + CBClinica.Text + "','1','" + txtDependencia.Text + "');"
                                                      , "hgbdracr_pacientes", "Error En btnAceptar->Insertar Paciente");
                                        if (r > 0)
                                        {
                                            //Registrar movimiento
                                            Fecha = Fecha + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                                            con.Ejecutar_Accion("INSERT INTO movimientos (`Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                           + " VALUES ('" + usuario + "', 'hgbdracr_pacientes','Alta Paciente','Paciente rfc=" + txtRFC.Text + " Nombre=" + txtApellidoP.Text + txtApellidoM.Text + "', '" + Fecha + "');"
                                                           , "hgbdracr_censo", "Error En btnAceptar->Insertar Movimiento");

                                            //Insertar Relacion
                                            //Ejecutar_Accion("INSERT INTO `issste_hospital`.`medico_paciente` (`id_Medico_Paciente`, `No_Empleado`, `RFC_Pacientes`) VALUES (" + num_med + RFC + ",'" + num_med + "', '" + RFC + "');");
                                            //Imprimir@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                                            //ImprimirCB(RFC); 
                                            MessageBox.Show("Pacinete dado de alta");
                                            //AgendaCita AC = new AgendaCita(usuario, nombre, RFC,tipous ,txtApellidoP.Text,txtApellidoM.Text,txtNombre.Text);
                                            //AC.ShowDialog();
                                            //pasado("");
                                            //AgendaCita AC = new AgendaCita(usuario, nombre, RFC, Tipo);
                                            //AC.ShowDialog();
                                        }*/

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
                        catch (Exception exp)
                        {
                            MessageBox.Show("Error:" + exp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else { MessageBox.Show("Capture los telefonos\n(De casa y de celular o Clinica)\n O Dependencia"); }
                }
                else { MessageBox.Show("Revise los Datos de la Direccion\n(Calle,Numero,Colonia o Municipio)"); }
            }
            else { MessageBox.Show("Revise los Datos Personales\n(RFC,Tipo,Folio,Edad o Nombre)"); }
        }
        public void altarapida()
        {
            if (!txtApellidoP.Text.Equals("") && !txtNombre.Text.Equals(""))
            {
                //String RFC = txtRFC.Text.Replace(" ","");
                try
                {
                    DialogResult result;
                    result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nRFC: " + txtApellidoM.Text + "\nNombre: " + txtApellidoP.Text + " "
                             + txtApellidoM.Text + " " + txtNombre.Text + "\nTELEFONOS\n\nCasa: " + txtTel_Casa.Text
                             + "\nCelular: " + txtTel_Celular.Text , "Aceptar", MessageBoxButtons.YesNo);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            Confirmacion CF = new Confirmacion(usuario, nombre);
                            CF.pasado += new Confirmacion.pasar(PonerTexto);
                            CF.ShowDialog();
                            if (confirmacion.Equals("bien"))
                            {
                                //String RFC = txtRFC.Text + CBTipo.Text.Substring(0, 2) + repetido;
                                /*String Fecha = hoy.Year.ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Day.ToString();
                                String Sexo = CBSexo.Text.Substring(0, 1);
                                //Da De Alta al paciente
                                r = con.Ejecutar_Accion("INSERT INTO paciente (`RFC`, `ApellidoP`, `ApellidoM`, `Nombre`, `Calle`,"
                                              + " `No`, `Colonia`, `CP`, `Tel_Casa`, `Tel_Celular`, `Tel_Familiar`, `Municipio`, `Edad`,"
                                              + " `Observaciones`, `Tipo`, `Fec_Ingreso`, `Sexo`, `Clinica_Procedencia`, `Activo`,`Dependencia`) VALUES ('" + RFC + "', '" + txtApellidoP.Text + "', '"
                                              + txtApellidoM.Text + "'," + " '" + txtNombre.Text + "', '" + txtCalle.Text + "', '" + txtNumero.Text + "', '" + txtColonia.Text + "', '"
                                              + txtCP.Text + "', '" + txtTel_Casa.Text + "', '" + txtTel_Celular.Text + "', '" + txtTel_Familiar.Text + "', '" + CBMunicipio.Text + "'"
                                              + ", '" + DTPFecNac.Value.Year + "', '" + RTBObservaciones.Text + "', '" + Tipo + "', '" + Fecha + "','" + Sexo + "','" + CBClinica.Text + "','1','" + txtDependencia.Text + "');"
                                              , "hgbdracr_pacientes", "Error En btnAceptar->Insertar Paciente");
                                if (r > 0)
                                {
                                    //Registrar movimiento
                                    Fecha = Fecha + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                                    con.Ejecutar_Accion("INSERT INTO movimientos (`Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                   + " VALUES ('" + usuario + "', 'hgbdracr_pacientes','Alta Paciente','Paciente rfc=" + txtRFC.Text + " Nombre=" + txtApellidoP.Text + txtApellidoM.Text + "', '" + Fecha + "');"
                                                   , "hgbdracr_censo", "Error En btnAceptar->Insertar Movimiento");

                                    //Insertar Relacion
                                    //Ejecutar_Accion("INSERT INTO `issste_hospital`.`medico_paciente` (`id_Medico_Paciente`, `No_Empleado`, `RFC_Pacientes`) VALUES (" + num_med + RFC + ",'" + num_med + "', '" + RFC + "');");
                                    //Imprimir@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                                    //ImprimirCB(RFC); 
                                    MessageBox.Show("Pacinete dado de alta");
                                    //AgendaCita AC = new AgendaCita(usuario, nombre, RFC,tipous ,txtApellidoP.Text,txtApellidoM.Text,txtNombre.Text);
                                    //AC.ShowDialog();
                                    //pasado("");
                                    //AgendaCita AC = new AgendaCita(usuario, nombre, RFC, Tipo);
                                    //AC.ShowDialog();
                                }*/

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
                catch (Exception exp)
                {
                    MessageBox.Show("Error:" + exp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Revise los Datos Personales\n(Nombre)"); }
        }
        public void cargarmodificar()
        {
            txtApellidoM.Enabled = false;
            TablaU = con.Ejecutar_Consulta("SELECT * FROM paciente WHERE id_Paciente=" + id_b + ";"
                , "hgbdracr_pacientes", "Error En Paciente Load->Modificar->Selecionar Paciente");

            txtApellidoM.Text = TablaU.Rows[0]["RFC"].ToString();
            txtNombre.Text = TablaU.Rows[0]["Nombre"].ToString();
            txtApellidoP.Text = TablaU.Rows[0]["ApellidoP"].ToString();
            txtApellidoM.Text = TablaU.Rows[0]["ApellidoM"].ToString();
            txtCalle.Text = TablaU.Rows[0]["Calle"].ToString();
            txtNumero.Text = TablaU.Rows[0]["No"].ToString();
            txtColonia.Text = TablaU.Rows[0]["Colonia"].ToString();
            txtCP.Text = TablaU.Rows[0]["CP"].ToString();
            //txtDependencia.Text = TablaU.Rows[0]["Dependencia"].ToString();
            txtTel_Casa.Text = TablaU.Rows[0]["Tel_Casa"].ToString();
            txtTel_Celular.Text = TablaU.Rows[0]["Tel_Celular"].ToString();
            //txtTel_Familiar.Text = TablaU.Rows[0]["Tel_Familiar"].ToString();
            RTBObservaciones.Text = TablaU.Rows[0]["Observaciones"].ToString();

            if (TablaU.Rows[0]["Sexo"].ToString().Equals("M"))
            {
                //CBSexo.SelectedIndex = 0;
            }
            else
            {
                //CBSexo.SelectedIndex = 1;
            }
            CBMunicipio.Text = TablaU.Rows[0]["Municipio"].ToString();
            CBMunicipio.Text = TablaU.Rows[0]["Clinica_Procedencia"].ToString();
        }
        //TXT
        //BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            switch (Movimiento)
            {
                case "Alta":
                    alta();
                    break;
                case "Modificar":
                    if (!txtApellidoP.Text.Equals("") &&  !txtNombre.Text.Equals(""))
                    {
                        if (!txtCalle.Text.Equals("") && !txtNumero.Text.Equals("") && !txtColonia.Text.Equals("") && !CBMunicipio.Text.Equals("Seleccione Una Opcion..."))
                        {
                            if (!txtTel_Casa.Text.Equals("") && !txtTel_Celular.Text.Equals("") && !CBMunicipio.Text.Equals("Seleccione Una Opcion..."))
                            {
                                try
                                {
                                    DialogResult result;
                                    result = MessageBox.Show("Revice Los Datos ¿Estan Bien?\nRFC: " + txtApellidoM.Text + "\nNombre: " + txtApellidoP.Text + " "
                                             + txtApellidoM.Text + " " + txtNombre.Text + "\nDomicilio: " + txtCalle.Text + " #" + txtNumero.Text + " \nCol. " + txtColonia.Text
                                             + "CP" + txtCP.Text + " Municipio: " + CBMunicipio.Text + "\n\nTELEFONOS\n\nCasa: " + txtTel_Casa.Text
                                             + "\nCelular: " + txtTel_Celular.Text  + "\nClinica: "
                                             + CBMunicipio.Text, "Aceptar", MessageBoxButtons.YesNo);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            Confirmacion CF = new Confirmacion(usuario, nombre);
                                            CF.pasado += new Confirmacion.pasar(PonerTexto);
                                            CF.ShowDialog();
                                            if (confirmacion.Equals("bien"))
                                            {
                                                /*String Tipo = CBTipo.Text.Substring(0, 2), Fecha = hoy.Year.ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Day.ToString();
                                                String Sexo = CBSexo.Text.Substring(0, 1);
                                                //Modifica el paciente
                                                r=con.Ejecutar_Accion("UPDATE paciente SET Nombre = '" + txtNombre.Text
                                                  + "',ApellidoP = '" + txtApellidoP.Text
                                                  + "',ApellidoM = '" + txtApellidoM.Text
                                                  + "',Calle = '" + txtCalle.Text
                                                  + "',No = '" + txtNumero.Text
                                                  + "',Colonia = '" + txtColonia.Text
                                                  + "',CP = " + txtCP.Text
                                                  + ",Tel_Casa = '" + txtTel_Casa.Text
                                                  + "',Tel_Celular = '" + txtTel_Celular.Text
                                                  + "',Tel_Familiar = '" + txtTel_Familiar.Text
                                                  + "',Municipio = '" + CBMunicipio.Text
                                                  + "',Edad = " + txt_Edad.Text
                                                  + ",Observaciones = '" + RTBObservaciones.Text
                                                  + "',Tipo = '" + CBTipo.Text.Substring(0, 2)
                                                  + "',Sexo = '" + CBSexo.Text.Substring(0, 1)
                                                  + "',Clinica_Procedencia = '" + CBClinica.Text
                                                  + "',Dependencia = '" + txtDependencia.Text
                                                  + "' WHERE id_Paciente= " + id_b + ";"
                                                  , "hgbdracr_pacientes", "Error En btnAceptar->Modificar->Modificar Valores En Paciente");
                                                   
                                                if(r>0)
                                                {
                                                    //Registrar movimiento
                                                    Fecha = Fecha + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                                                    con.Ejecutar_Accion("INSERT INTO movimientos (`Usuario`, `Tabla`, `Tipo`, `Observacion`, `Fecha`)"
                                                                   + " VALUES ('" + usuario + "', 'BD->Pacientes', 'Modificar Paciente','"+id_b+"', '" + Fecha + "');"
                                                                   , "hgbdracr_censo", "Error En btnAceptar->Insertar Movimiento");
                                                    
                                                    MessageBox.Show("Pacinete Modificado", "Modificado");
                                                    pasado(txtRFC.Text);
                                                }                                             
                                                */
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
                                catch (Exception exp)
                                {
                                    MessageBox.Show("Error:" + exp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else { MessageBox.Show("Capture los telefonos\n(De casa y de celular o Clinica)\n O Dependencia"); }
                        }
                        else { MessageBox.Show("Revise los Datos de la Direccion\n(Calle,Numero,Colonia o Municipio)"); }
                    }
                    else { MessageBox.Show("Revise los Datos Personales\n(RFC,Tipo,Folio,Edad o Nombre)"); }
                    break;
                default:
                    break;
            }            
        }

        //EVENTOS
        private void Alta_Paciente_Load(object sender, EventArgs e)
        {
            //hoy = DateTime.Parse(con.Ejecutar_Consulta("select now();", "hgbdracr_rh", "Error al obtener fecha").Rows[0][0].ToString());
            mayusculas();
            url = con.url("FormatosCE");
            switch (Movimiento)
            {
                case "Alta":
                    break;
                case "Rapido":

                    CBMotivo.SelectedIndex = 0;
                    CBReferido.SelectedIndex = 0;
                    CBEstado.SelectedIndex = 0;
                    CBMunicipio.SelectedIndex = 0;
                    break;
                case "Modificar":
                    cargarmodificar();
                    break;
                default:
                    break;
            }
        }

        private void txt_Edad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Movimiento)
            {
                case "Alta":
                    break;
                default:
                    break;
            }
        }        

        private void CBTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBClinica_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
         
        
    }
}
