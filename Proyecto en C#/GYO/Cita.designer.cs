namespace GYO
{
    partial class Cita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cita));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Agendar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fec_Reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTipo = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LNombrePac = new System.Windows.Forms.Label();
            this.LMedico = new System.Windows.Forms.Label();
            this.LFecha = new System.Windows.Forms.Label();
            this.LObservaciones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Agendar,
            this.Turno,
            this.Horario,
            this.Paciente,
            this.Usu,
            this.Fec_Reg});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(900, 358);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Agendar
            // 
            this.Agendar.HeaderText = "Agrendar";
            this.Agendar.Name = "Agendar";
            this.Agendar.ReadOnly = true;
            this.Agendar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Agendar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Agendar.Text = "Agregar";
            this.Agendar.Width = 75;
            // 
            // Turno
            // 
            this.Turno.HeaderText = "Turno";
            this.Turno.Name = "Turno";
            this.Turno.ReadOnly = true;
            this.Turno.Width = 60;
            // 
            // Horario
            // 
            this.Horario.HeaderText = "Horario";
            this.Horario.Name = "Horario";
            this.Horario.ReadOnly = true;
            this.Horario.Width = 66;
            // 
            // Paciente
            // 
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            this.Paciente.Width = 74;
            // 
            // Usu
            // 
            this.Usu.HeaderText = "Usuario";
            this.Usu.Name = "Usu";
            this.Usu.ReadOnly = true;
            this.Usu.Width = 68;
            // 
            // Fec_Reg
            // 
            this.Fec_Reg.HeaderText = "Fecha De Registro";
            this.Fec_Reg.Name = "Fec_Reg";
            this.Fec_Reg.ReadOnly = true;
            this.Fec_Reg.Width = 111;
            // 
            // LTipo
            // 
            this.LTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTipo.AutoSize = true;
            this.LTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LTipo.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTipo.Location = new System.Drawing.Point(12, 583);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(2, 19);
            this.LTipo.TabIndex = 100;
            // 
            // LNombre
            // 
            this.LNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(12, 560);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(0, 13);
            this.LNombre.TabIndex = 99;
            // 
            // LNombrePac
            // 
            this.LNombrePac.AutoSize = true;
            this.LNombrePac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombrePac.ForeColor = System.Drawing.Color.Red;
            this.LNombrePac.Location = new System.Drawing.Point(168, 20);
            this.LNombrePac.Name = "LNombrePac";
            this.LNombrePac.Size = new System.Drawing.Size(112, 24);
            this.LNombrePac.TabIndex = 101;
            this.LNombrePac.Text = "PACIENTE";
            // 
            // LMedico
            // 
            this.LMedico.AutoSize = true;
            this.LMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMedico.ForeColor = System.Drawing.Color.Blue;
            this.LMedico.Location = new System.Drawing.Point(178, 57);
            this.LMedico.Name = "LMedico";
            this.LMedico.Size = new System.Drawing.Size(90, 24);
            this.LMedico.TabIndex = 102;
            this.LMedico.Text = "MEDICO";
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFecha.ForeColor = System.Drawing.Color.Indigo;
            this.LFecha.Location = new System.Drawing.Point(131, 93);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(95, 31);
            this.LFecha.TabIndex = 103;
            this.LFecha.Text = "Fecha";
            // 
            // LObservaciones
            // 
            this.LObservaciones.AutoSize = true;
            this.LObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LObservaciones.ForeColor = System.Drawing.Color.Black;
            this.LObservaciones.Location = new System.Drawing.Point(229, 134);
            this.LObservaciones.Name = "LObservaciones";
            this.LObservaciones.Size = new System.Drawing.Size(209, 31);
            this.LObservaciones.TabIndex = 104;
            this.LObservaciones.Text = "Observaciones";
            // 
            // Cita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(924, 611);
            this.Controls.Add(this.LObservaciones);
            this.Controls.Add(this.LFecha);
            this.Controls.Add(this.LMedico);
            this.Controls.Add(this.LNombrePac);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cita";
            this.Load += new System.EventHandler(this.Cita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LNombrePac;
        private System.Windows.Forms.Label LMedico;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LObservaciones;
        private System.Windows.Forms.DataGridViewButtonColumn Agendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fec_Reg;
    }
}