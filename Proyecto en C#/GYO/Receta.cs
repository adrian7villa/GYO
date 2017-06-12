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
    public partial class Receta : Form
    {
        public Receta()
        {
            InitializeComponent();
        }
        private void PonerOtro(string c)
        {
            otro = c;
        }
        Conexion con = new Conexion();
        string otro = "";
        DataTable TMedicamento;
        public void CargarMedicamento()
        {
            TMedicamento = con.Ejecutar_Consulta("SELECT DISTINCT `Acronimo` FROM `autoridades`;", "hgbdracr_rh", "Error a cargar Autoridades en load");
            if (TMedicamento.Rows.Count >= 1)
            {
                for (int i = 0; i < TMedicamento.Rows.Count; i++)
                {
                    CBMedicamento.Items.Add(TMedicamento.Rows[i]["Acronimo"].ToString());
                }
                CBMedicamento.SelectedIndex = 0;
            }
        }
        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMedicamento.Text.Equals("Otro..."))
            {
                Medicamento med = new Medicamento();
                med.ShowDialog();
                CargarMedicamento();
            }
        }
    }
}
