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
    public partial class Nuevo_Elemento : Form
    {
        public Nuevo_Elemento()
        {
            InitializeComponent();
        }
        public Nuevo_Elemento(string lnombre)
        {
            InitializeComponent();
            label2.Text = lnombre;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
        }
        public Nuevo_Elemento(string lnombre,string tip)
        {
            InitializeComponent();
            label2.Text = lnombre;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            tipo = tip;
            switch(tip)
            {
                case "combo":
                    CBMotivo.Visible = true;
                    txtNombre.Visible = false;
                    cargarmotivos();
                    break;
            }
        }
        
        //DELEGADOS
        public delegate void pasar(string dato);
        public event pasar pasado;
        //Variables
        DataTable TablaM = new DataTable();
        Conexion con = new Conexion();
        string tipo;
        //Funciones
        public void cargarmotivos()
        {
            CBMotivo.Items.Clear();
            TablaM = con.Ejecutar_Consulta("SELECT * FROM `motivo` ORDER BY `Nombre`;", "gyo", "Error a cargar Motivos en load");
            if (TablaM.Rows.Count >= 1)
            {
                for (int i = 0; i < TablaM.Rows.Count; i++)
                {
                    CBMotivo.Items.Add(TablaM.Rows[i]["Nombre"].ToString());
                }

                CBMotivo.SelectedIndex = 0;
            }
        }
        //Botones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case "combo":
                    pasado(CBMotivo.Text);
                    this.Close();

                    break;
                case "txt":
                    if (!txtNombre.Text.Equals(""))
                    {
                        pasado(txtNombre.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Coloque Un Nombre");
                    }
                    break;
            }
            
        }

        private void CBMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //
    }
}
