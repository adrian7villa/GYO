//Borrar la relacion de medicos estudio
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using exel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace GYO
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }
        public Buscar(string us, string nom, string tip)
        {
            InitializeComponent();
            Usuario = us;
            LNombre.Text = Nombre = nom;
            LTipo.Text = Tipo = tip;      
        }
        public Buscar(string us, string nom, string tip,string busca)
        {
            InitializeComponent();
            Usuario = us;
            LNombre.Text = Nombre = nom;
            LTipo.Text = Tipo = tip;
            Accion = busca;
        }
        //DELEGADOS
        public delegate void pasar(string dato);
        public event pasar pasado;
        //DELEGADOS
        //   Locales
        private void PonerTexto(string c)//Modi
        {
            dataGridView1.DataSource = con.Ejecutar_Consulta("SELECT * FROM Paciente WHERE RFC LIKE '%" + c
                                       + "%' OR Nombre LIKE '%" + c
                                       + "%' OR ApellidoP LIKE '%" + c
                                       + "%' OR ApellidoM LIKE '%" + c
                                       + "%' OR Colonia LIKE '%" + c
                                       + "%' OR CP LIKE '%" + c
                                       + "%' OR Municipio LIKE '%" + c
                                       + "%' OR Edad LIKE '%" + c
                                       + "%' OR Tipo LIKE '%" + c
                                       + "%' OR Fec_Ingreso LIKE '%" + c
                                       + "%' OR Sexo LIKE '%" + c
                                       + "%' OR Dependencia LIKE '%" + c
                                       + "%' OR Clinica_Procedencia LIKE '%" + c + "%'; "
                                       , "Consulta_Externa", "Error en btnBuscar->Pacientes->Buscar Pacientes");
        }
        //VARIABLES
        Conexion con = new Conexion();
        DataTable TablaD,TablaDICRX;
        string Tipo, Nombre, Usuario,Accion;
        //FUNCIONES
        public void mayusculas()
        {
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)//Agregar
        {
            switch (Accion)
            {
                case "Agendar":
                    Agenda age = new Agenda(Usuario, LNombre.Text, LTipo.Text,dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id_Paciente"].Value.ToString());
                    age.ShowDialog();
                    this.Close();
                    break;
                case "RegistrarPaciente":
                    break;
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaRapida altrap = new AltaRapida(Usuario,LNombre.Text,LTipo.Text);
            altrap.ShowDialog();
        }

        //EVENTOS
        private void Buscar_Load(object sender, EventArgs e)//Agregar
        {
            mayusculas();
            switch (Accion)
            {
                case "Agendar":
                    btnAgregar.Visible = true;
                    break;
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)//Modi
        {
            if(dataGridView1.Rows.Count>0)
            {
                //int nf = dataGridView1.CurrentCell.RowIndex;
                //Alta_Paciente apac = new Alta_Paciente(Usuario, LNombre.Text,LTipo.Text, "Modificar", dataGridView1.Rows[nf].Cells[0].Value.ToString());
                //apac.pasado += new Alta_Paciente.pasar(PonerTexto);
                //apac.Text = "Modificar Paciente";
                //apac.ShowDialog();
            }
            
        }
        //BOTONES
        private void btnBuscar_Click(object sender, EventArgs e)//Agregar
        {
            switch(Accion)
            {
                case "Agendar":
                    dataGridView1.DataSource = con.Ejecutar_Consulta("SELECT RFC,ApellidoP,ApellidoM,Nombre,Tel_Cel,Calle,Colonia,id_Paciente FROM Paciente WHERE RFC LIKE '%" + txtBuscar.Text
                                       + "%' OR Nombre LIKE '%" + txtBuscar.Text
                                       + "%' OR ApellidoP LIKE '%" + txtBuscar.Text
                                       + "%' OR ApellidoM LIKE '%" + txtBuscar.Text+"%'"
                                       , "gyo", "Error en btnBuscar->Pacientes->Buscar Pacientes");
                    dataGridView1.Columns["id_Paciente"].Visible = false;
                    break;
            }
            
        }  
    }
}
