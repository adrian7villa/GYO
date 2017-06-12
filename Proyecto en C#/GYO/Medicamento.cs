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
    public partial class Medicamento : Form
    {
        public Medicamento()
        {
            InitializeComponent();
        }
        private void PonerOtro(string c)
        {
            otro = c;
        }
        string otro = "";

        private void CBPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPresentacion.Text.Equals("Otro..."))
            {
                Nuevo_Elemento NE = new Nuevo_Elemento();
                NE.Text = "Nuevo Medicamento";
                NE.pasado += new Nuevo_Elemento.pasar(PonerOtro);
                NE.ShowDialog();
                CBPresentacion.Items.Add(otro);
            }
        }
    }
}
