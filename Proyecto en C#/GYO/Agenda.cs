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
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
        }
        public Agenda(string us, string nom, string tip)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = us;
            LTipo.Text = tip;
        }
        public Agenda(string us, string nom, string tip,string idpac)
        {
            InitializeComponent();
            LNombre.Text = nom;
            usuario = us;
            LTipo.Text = tip;
            paciente = idpac;
        }
        //Delegado
        private void PonerCitado(string c)//Modi
        {
            if (c.Equals("Citado"))
            {
                this.Close();

            }
        }
        string usuario,paciente;
        DateTime fechagenda = DateTime.Today;
        private void Agenda_Load(object sender, EventArgs e)
        {
            LMes.Text = fechagenda.ToString("MMMM").ToUpper() + " " + fechagenda.Year;
            fechagenda = new DateTime(fechagenda.Year, fechagenda.Month, 1);
            cambio(fechagenda);
        }

        public void ocultar()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button32.Visible = false;
            button33.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            button38.Visible = false;
            button39.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label41.Visible = false;
            label42.Visible = false;
            label43.Visible = false;
            label44.Visible = false;
        }
        public void marcar(int inicio, int fin, DateTime fecha, Boolean estado)
        {
            for (int i = inicio; i < (fin + inicio); i++)
            {
                switch (i)
                {
                    case 0:
                        button1.Visible = estado;
                        button1.Text = fecha.ToShortDateString();
                        //label8.Text = mostrarcitados(fecha, button1);
                        label8.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 1:
                        button2.Visible = estado;
                        button2.Text = fecha.ToShortDateString();
                        //label9.Text = mostrarcitados(fecha, button2);
                        label9.Visible = estado;
                        //button2.BackColor = Color.Red;
                        fecha = fecha.AddDays(1);
                        break;
                    case 2:
                        button3.Visible = estado;
                        button3.Text = fecha.ToShortDateString();
                        //label10.Text = mostrarcitados(fecha, button3);
                        label10.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 3:
                        button4.Visible = estado;
                        button4.Text = fecha.ToShortDateString();
                        //label11.Text = mostrarcitados(fecha, button4);
                        label11.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 4:
                        button5.Visible = estado;
                        button5.Text = fecha.ToShortDateString();
                        //label12.Text = mostrarcitados(fecha, button5);
                        label12.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 5:
                        button6.Visible = estado;
                        button6.Text = fecha.ToShortDateString();
                        //label13.Text = mostrarcitados(fecha, button6);
                        label13.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 6:
                        button7.Visible = estado;
                        button7.Text = fecha.ToShortDateString();
                        //label14.Text = mostrarcitados(fecha, button7);
                        label14.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 7:
                        button8.Visible = estado;
                        button8.Text = fecha.ToShortDateString();
                        //label21.Text = mostrarcitados(fecha, button8);
                        label21.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 8:
                        button9.Visible = estado;
                        button9.Text = fecha.ToShortDateString();
                        //label20.Text = mostrarcitados(fecha, button9);
                        label20.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 9:
                        button10.Visible = estado;
                        button10.Text = fecha.ToShortDateString();
                        //label19.Text = mostrarcitados(fecha, button10);
                        label19.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 10:
                        button11.Visible = estado;
                        button11.Text = fecha.ToShortDateString();
                        //label18.Text = mostrarcitados(fecha, button11);
                        label18.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 11:
                        button12.Visible = estado;
                        button12.Text = fecha.ToShortDateString();
                        //label17.Text = mostrarcitados(fecha, button12);
                        label17.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 12:
                        button13.Visible = estado;
                        button13.Text = fecha.ToShortDateString();
                        //label16.Text = mostrarcitados(fecha, button13);
                        label16.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 13:
                        button14.Visible = estado;
                        button14.Text = fecha.ToShortDateString();
                        //label15.Text = mostrarcitados(fecha, button14);
                        label15.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 14:
                        button15.Visible = estado;
                        button15.Text = fecha.ToShortDateString();
                        //label28.Text = mostrarcitados(fecha, button15);
                        label28.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 15:
                        button16.Visible = estado;
                        button16.Text = fecha.ToShortDateString();
                        //label27.Text = mostrarcitados(fecha, button16);
                        label27.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 16:
                        button17.Visible = estado;
                        button17.Text = fecha.ToShortDateString();
                        //label26.Text = mostrarcitados(fecha, button17);
                        label26.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 17:
                        button18.Visible = estado;
                        button18.Text = fecha.ToShortDateString();
                        //label25.Text = mostrarcitados(fecha, button18);
                        label25.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 18:
                        button19.Visible = estado;
                        button19.Text = fecha.ToShortDateString();
                        //label24.Text = mostrarcitados(fecha, button19);
                        label24.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 19:
                        button20.Visible = estado;
                        button20.Text = fecha.ToShortDateString();
                        //label23.Text = mostrarcitados(fecha, button20);
                        label23.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 20:
                        button21.Visible = estado;
                        button21.Text = fecha.ToShortDateString();
                        //label22.Text = mostrarcitados(fecha, button21);
                        label22.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 21:
                        button22.Visible = estado;
                        button22.Text = fecha.ToShortDateString();
                        //label35.Text = mostrarcitados(fecha, button22);
                        label35.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 22:
                        button23.Visible = estado;
                        button23.Text = fecha.ToShortDateString();
                        //label34.Text = mostrarcitados(fecha, button23);
                        label34.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 23:
                        button24.Visible = estado;
                        button24.Text = fecha.ToShortDateString();
                        //label33.Text = mostrarcitados(fecha, button24);
                        label33.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 24:
                        button25.Visible = estado;
                        button25.Text = fecha.ToShortDateString();
                        //label32.Text = mostrarcitados(fecha, button25);
                        label32.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 25:
                        button26.Visible = estado;
                        button26.Text = fecha.ToShortDateString();
                        //label31.Text = mostrarcitados(fecha, button26);
                        label31.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 26:
                        button27.Visible = estado;
                        button27.Text = fecha.ToShortDateString();
                        //label30.Text = mostrarcitados(fecha, button27);
                        label30.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 27:
                        button28.Visible = estado;
                        button28.Text = fecha.ToShortDateString();
                        //label29.Text = mostrarcitados(fecha, button28);
                        label29.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 28:
                        button29.Visible = estado;
                        button29.Text = fecha.ToShortDateString();
                        //label42.Text = mostrarcitados(fecha, button29);
                        label42.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 29:
                        button30.Visible = estado;
                        button30.Text = fecha.ToShortDateString();
                        //label41.Text = mostrarcitados(fecha, button30);
                        label41.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 30:
                        button31.Visible = estado;
                        button31.Text = fecha.ToShortDateString();
                        //label40.Text = mostrarcitados(fecha, button31);
                        label40.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 31:
                        button32.Visible = estado;
                        button32.Text = fecha.ToShortDateString();
                        //label39.Text = mostrarcitados(fecha, button32);
                        label39.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 32:
                        button33.Visible = estado;
                        button33.Text = fecha.ToShortDateString();
                        //label38.Text = mostrarcitados(fecha, button33);
                        label38.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 33:
                        button34.Visible = estado;
                        button34.Text = fecha.ToShortDateString();
                        //label37.Text = mostrarcitados(fecha, button34);
                        label37.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 34:
                        button35.Visible = estado;
                        button35.Text = fecha.ToShortDateString();
                        //label36.Text = mostrarcitados(fecha, button35);
                        label36.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 35:
                        button38.Visible = estado;
                        button38.Text = fecha.ToShortDateString();
                        //label44.Text = mostrarcitados(fecha, button38);
                        label44.Visible = estado;
                        fecha = fecha.AddDays(1);
                        break;
                    case 36:
                        button39.Visible = estado;
                        button39.Text = fecha.ToShortDateString();
                        //label43.Text = mostrarcitados(fecha, button39);
                        label43.Visible = estado;
                        break;
                }
            }
        }
        public void marcarinicidencia(int inicio, int fin, Boolean estado)
        {
            for (int i = inicio; i <= fin; i++)
            {
                switch (i)
                {
                    case 0:
                        button1.Visible = estado;
                        //button1.Text = fecha.ToShortDateString();
                        label8.Visible = estado;
                        break;
                    case 1:
                        button2.Visible = estado;
                        //button2.Text = fecha.ToShortDateString();
                        label9.Visible = estado;
                        //button2.BackColor = Color.Red;
                        break;
                    case 2:
                        button3.Visible = estado;
                        //button3.Text = fecha.ToShortDateString();
                        label10.Visible = estado;
                        break;
                    case 3:
                        button4.Visible = estado;
                        //button4.Text = fecha.ToShortDateString();
                        label11.Visible = estado;
                        break;
                    case 4:
                        button5.Visible = estado;
                        //button5.Text = fecha.ToShortDateString();
                        label12.Visible = estado;
                        break;
                    case 5:
                        button6.Visible = estado;
                        //button6.Text = fecha.ToShortDateString();
                        label13.Visible = estado;
                        break;
                    case 6:
                        button7.Visible = estado;
                        //button7.Text = fecha.ToShortDateString();
                        label14.Visible = estado;
                        break;
                    case 7:
                        button8.Visible = estado;
                        //button8.Text = fecha.ToShortDateString();
                        label21.Visible = estado;
                        break;
                    case 8:
                        button9.Visible = estado;
                        //button9.Text = fecha.ToShortDateString();
                        label20.Visible = estado;
                        break;
                    case 9:
                        button10.Visible = estado;
                        //button10.Text = fecha.ToShortDateString();
                        label19.Visible = estado;
                        break;
                    case 10:
                        button11.Visible = estado;
                        //button11.Text = fecha.ToShortDateString();
                        label18.Visible = estado;
                        break;
                    case 11:
                        button12.Visible = estado;
                        //button12.Text = fecha.ToShortDateString();
                        label17.Visible = estado;
                        break;
                    case 12:
                        button13.Visible = estado;
                        //button13.Text = fecha.ToShortDateString();
                        label16.Visible = estado;
                        break;
                    case 13:
                        button14.Visible = estado;
                        //button14.Text = fecha.ToShortDateString();
                        label15.Visible = estado;
                        break;
                    case 14:
                        button15.Visible = estado;
                        //button15.Text = fecha.ToShortDateString();
                        label28.Visible = estado;
                        break;
                    case 15:
                        button16.Visible = estado;
                        //button16.Text = fecha.ToShortDateString();
                        label27.Visible = estado;
                        break;
                    case 16:
                        button17.Visible = estado;
                        //button17.Text = fecha.ToShortDateString();
                        label26.Visible = estado;
                        break;
                    case 17:
                        button18.Visible = estado;
                        //button18.Text = fecha.ToShortDateString();
                        label25.Visible = estado;
                        break;
                    case 18:
                        button19.Visible = estado;
                        //button19.Text = fecha.ToShortDateString();
                        label24.Visible = estado;
                        break;
                    case 19:
                        button20.Visible = estado;
                        //button20.Text = fecha.ToShortDateString();
                        label23.Visible = estado;
                        break;
                    case 20:
                        button21.Visible = estado;
                        //button21.Text = fecha.ToShortDateString();
                        label22.Visible = estado;
                        break;
                    case 21:
                        button22.Visible = estado;
                        //button22.Text = fecha.ToShortDateString();
                        label35.Visible = estado;
                        break;
                    case 22:
                        button23.Visible = estado;
                        //button23.Text = fecha.ToShortDateString();
                        label34.Visible = estado;
                        break;
                    case 23:
                        button24.Visible = estado;
                        //button24.Text = fecha.ToShortDateString();
                        label33.Visible = estado;
                        break;
                    case 24:
                        button25.Visible = estado;
                        //button25.Text = fecha.ToShortDateString();
                        label32.Visible = estado;
                        break;
                    case 25:
                        button26.Visible = estado;
                        //button26.Text = fecha.ToShortDateString();
                        label31.Visible = estado;
                        break;
                    case 26:
                        button27.Visible = estado;
                        //button27.Text = fecha.ToShortDateString();
                        label30.Visible = estado;
                        break;
                    case 27:
                        button28.Visible = estado;
                        //button28.Text = fecha.ToShortDateString();
                        label29.Visible = estado;
                        break;
                    case 28:
                        button29.Visible = estado;
                        //button29.Text = fecha.ToShortDateString();
                        label42.Visible = estado;
                        break;
                    case 29:
                        button30.Visible = estado;
                        //button30.Text = fecha.ToShortDateString();
                        label41.Visible = estado;
                        break;
                    case 30:
                        button31.Visible = estado;
                        //button31.Text = fecha.ToShortDateString();
                        label40.Visible = estado;
                        break;
                    case 31:
                        button32.Visible = estado;
                        //button32.Text = fecha.ToShortDateString();
                        label39.Visible = estado;
                        break;
                    case 32:
                        button33.Visible = estado;
                        //button33.Text = fecha.ToShortDateString();
                        label38.Visible = estado;
                        break;
                    case 33:
                        button34.Visible = estado;
                        //button34.Text = fecha.ToShortDateString();
                        label37.Visible = estado;
                        break;
                    case 34:
                        button35.Visible = estado;
                        //button35.Text = fecha.ToShortDateString();
                        label36.Visible = estado;
                        break;
                    case 35:
                        button38.Visible = estado;
                        //button38.Text = fecha.ToShortDateString();
                        label44.Visible = estado;
                        break;
                    case 36:
                        button39.Visible = estado;
                        //button39.Text = fecha.ToShortDateString();
                        label43.Visible = estado;
                        break;
                }
            }
        }
        public void cambio(DateTime fechanueva)
        {
            ocultar();
            int diasmes = 0;
            diasmes = DateTime.DaysInMonth(fechanueva.Year, fechanueva.Month);
            marcar((int)fechanueva.DayOfWeek, diasmes, fechanueva,true);

        }

        private void button36_Click(object sender, EventArgs e)
        {
            string mes = LMes.Text.Substring(0, LMes.Text.Length - 5), ano = LMes.Text.Substring(LMes.Text.Length - 4, 4);
            fechagenda = fechagenda.AddMonths(1);
            fechagenda = new DateTime(fechagenda.Year, fechagenda.Month, 1);
            LMes.Text = fechagenda.ToString("MMMM").ToUpper() + " " + fechagenda.Year;
            cambio(fechagenda);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string mes = LMes.Text.Substring(0, LMes.Text.Length - 5), ano = LMes.Text.Substring(LMes.Text.Length - 4, 4);
            fechagenda = fechagenda.AddMonths(-1);
            fechagenda = new DateTime(fechagenda.Year, fechagenda.Month, 1);
            LMes.Text = fechagenda.ToString("MMMM").ToUpper() + " " + fechagenda.Year;
            cambio(fechagenda);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1");
            DateTime feccita = DateTime.Parse(((Button)sender).Text);
            Cita cit = new Cita(usuario,LNombre.Text,LTipo.Text,paciente,feccita,"Cita");
            cit.pasado += new Cita.pasar(PonerCitado);
            cit.ShowDialog();
        }
    }
}
