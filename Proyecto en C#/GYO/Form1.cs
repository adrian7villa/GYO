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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string us, string nom, string tip)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = us;
            LTipo.Text = tip;
        }
        //VARIABLES##################################################################################
        Conexion con = new Conexion();
        DataTable TablaD,TCitados;
        DateTime hoy = new DateTime();
        string usuario;
        private void btnNPaciente_Click(object sender, EventArgs e)
        {
            Buscar bus = new Buscar(usuario, LNombre.Text, LTipo.Text, "RegistrarPaciente");
            bus.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnHojaSuplente_Click(object sender, EventArgs e)
        {
            //Agenda age = new Agenda(usuario,LNombre.Text,LTipo.Text);
            //age.ShowDialog();

            Buscar bus = new Buscar(usuario, LNombre.Text, LTipo.Text,"Agendar");
            bus.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Citado cit = new Citado(dataGridView1.Rows[e.RowIndex].Cells["btnNombre"].Value.ToString());
                cit.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hoy = DateTime.Now;
            
            if (LTipo.Text.Equals("DOCTORA") || LTipo.Text.Equals("ADMINISTRADOR"))
            {
                dataGridView1.Visible = true;
               TCitados= con.Ejecutar_Consulta("SELECT DISTINCT paciente.id_Paciente,paciente.ApellidoP"
                            +",paciente.ApellidoM,paciente.Nombre,cita.Motivo FROM cita INNER JOIN "
                            +"paciente ON  paciente.id_Paciente=cita.Paciente WHERE cita.Fecha = '"+hoy.Year+"/"+hoy.Month+"/"+hoy.Day+"'"
                            , "gyo","Error al consultar citados del dia");
                if (TCitados.Rows.Count>0)
                {
                    for(int i=0;i<TCitados.Rows.Count;i++)
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Id"].Value = TCitados.Rows[i]["id_paciente"].ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["btnNombre"].Value = TCitados.Rows[i]["ApellidoP"].ToString()+" "
                            + TCitados.Rows[i]["ApellidoM"].ToString()+" "
                            + TCitados.Rows[i]["Nombre"].ToString();
                    }
                }
            }
        }
    }
}
