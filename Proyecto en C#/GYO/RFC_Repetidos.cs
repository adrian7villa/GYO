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
    public partial class RFC_Repatidos : Form
    {
        public RFC_Repatidos()
        {
            InitializeComponent();
        }
        public RFC_Repatidos(string rfc)
        {
            InitializeComponent();
            rfc_o = rfc;
        }
        public RFC_Repatidos(string rfc,string usu,string tip,string nom)
        {
            InitializeComponent();
            rfc_o = rfc;
            usuario = usu;
            nombre = nom;
            Tipo = tip;
        }
        //DELEGEDOS
        public delegate void pasar(string dato);
        public event pasar pasado;
                
        //VARIABLES
        string rfc_o,tipo_dep,usuario="nada",nombre,Tipo;
        DataTable TablaM;
        Conexion con = new Conexion();
        //EVENTOS
        private void RFC_Repatidos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.Ejecutar_Consulta("SELECT * FROM paciente WHERE RFC='" + rfc_o + "';"
                        , "hgbdracr_pacientes", "Error En RFC_Repetidos_Load->Selecionar Paciente RFC");
            btnGenerar.Visible = true;
                       
        }
        private void RFC_Repatidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //pasado("Cerrar");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Dar de alta la relacion
            int nf = dataGridView1.CurrentCell.RowIndex;
            string nom = dataGridView1.Rows[nf].Cells["ApellidoP"].Value.ToString() + " " + dataGridView1.Rows[nf].Cells["ApellidoM"].Value.ToString() + " " + dataGridView1.Rows[nf].Cells["Nombre"].Value.ToString();

            DialogResult result1;
            result1 = MessageBox.Show("Este Es El Paciente Que Busca: \n" + nom, "Paciente", MessageBoxButtons.YesNo);
            switch (result1)
            {
                case DialogResult.Yes:
                    TablaM = con.Ejecutar_Consulta("SELECT Medico FROM medico_paciente WHERE `Paciente`='" + dataGridView1.Rows[nf].Cells["id_Paciente"].Value.ToString() + "' ORDER BY `Medico`;", "hgbdracr_ce", "Error a cargar Medicos en load");
                    switch (TablaM.Rows.Count)
                    {
                        case 1:
                            break;
                        case 0:
                            break;
                        default:
                            break;
                    }
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
        //BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            Alta_Paciente npaciete = new Alta_Paciente(usuario, nombre, Tipo, rfc_o);
            npaciete.Text = "Nuevo Paciente";
            npaciete.ShowDialog();
            this.Close();
        }
    }
}
