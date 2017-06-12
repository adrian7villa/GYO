namespace GYO
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHojaSuplente = new System.Windows.Forms.Button();
            this.btnDatosFac = new System.Windows.Forms.Button();
            this.btnNPaciente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LTipo = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.btnCambiar_Contra = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNombre = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHojaSuplente
            // 
            this.btnHojaSuplente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHojaSuplente.BackColor = System.Drawing.Color.Pink;
            this.btnHojaSuplente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHojaSuplente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHojaSuplente.Image = ((System.Drawing.Image)(resources.GetObject("btnHojaSuplente.Image")));
            this.btnHojaSuplente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHojaSuplente.Location = new System.Drawing.Point(710, 458);
            this.btnHojaSuplente.Name = "btnHojaSuplente";
            this.btnHojaSuplente.Size = new System.Drawing.Size(139, 74);
            this.btnHojaSuplente.TabIndex = 64;
            this.btnHojaSuplente.Text = "Agendar";
            this.btnHojaSuplente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHojaSuplente.UseVisualStyleBackColor = false;
            this.btnHojaSuplente.Click += new System.EventHandler(this.btnHojaSuplente_Click);
            // 
            // btnDatosFac
            // 
            this.btnDatosFac.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDatosFac.BackColor = System.Drawing.Color.Purple;
            this.btnDatosFac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDatosFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatosFac.ForeColor = System.Drawing.Color.White;
            this.btnDatosFac.Image = ((System.Drawing.Image)(resources.GetObject("btnDatosFac.Image")));
            this.btnDatosFac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatosFac.Location = new System.Drawing.Point(565, 458);
            this.btnDatosFac.Name = "btnDatosFac";
            this.btnDatosFac.Size = new System.Drawing.Size(139, 74);
            this.btnDatosFac.TabIndex = 63;
            this.btnDatosFac.Text = "Datos De\r\nFacturacion";
            this.btnDatosFac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatosFac.UseVisualStyleBackColor = false;
            // 
            // btnNPaciente
            // 
            this.btnNPaciente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNPaciente.BackColor = System.Drawing.Color.White;
            this.btnNPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNPaciente.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnNPaciente.Image = ((System.Drawing.Image)(resources.GetObject("btnNPaciente.Image")));
            this.btnNPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNPaciente.Location = new System.Drawing.Point(420, 458);
            this.btnNPaciente.Name = "btnNPaciente";
            this.btnNPaciente.Size = new System.Drawing.Size(139, 74);
            this.btnNPaciente.TabIndex = 62;
            this.btnNPaciente.Text = "Registrar\r\nPaciente";
            this.btnNPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNPaciente.UseVisualStyleBackColor = false;
            this.btnNPaciente.Click += new System.EventHandler(this.btnNPaciente_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1024, 642);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "ING. ADRIAN DAVID VILLASEÑOR ESTRADA";
            // 
            // LTipo
            // 
            this.LTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTipo.AutoSize = true;
            this.LTipo.BackColor = System.Drawing.Color.Transparent;
            this.LTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LTipo.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTipo.Location = new System.Drawing.Point(12, 640);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(2, 19);
            this.LTipo.TabIndex = 56;
            // 
            // LNombre
            // 
            this.LNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LNombre.AutoSize = true;
            this.LNombre.BackColor = System.Drawing.Color.Transparent;
            this.LNombre.Location = new System.Drawing.Point(12, 615);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(0, 13);
            this.LNombre.TabIndex = 55;
            // 
            // btnCambiar_Contra
            // 
            this.btnCambiar_Contra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiar_Contra.BackColor = System.Drawing.Color.DarkViolet;
            this.btnCambiar_Contra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCambiar_Contra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar_Contra.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiar_Contra.Image")));
            this.btnCambiar_Contra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiar_Contra.Location = new System.Drawing.Point(1103, 567);
            this.btnCambiar_Contra.Name = "btnCambiar_Contra";
            this.btnCambiar_Contra.Size = new System.Drawing.Size(154, 69);
            this.btnCambiar_Contra.TabIndex = 54;
            this.btnCambiar_Contra.Text = "Cambiar\r\nConstraseña";
            this.btnCambiar_Contra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiar_Contra.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1269, 38);
            this.menuStrip1.TabIndex = 68;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacienteToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(82, 34);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // pacienteToolStripMenuItem
            // 
            this.pacienteToolStripMenuItem.Name = "pacienteToolStripMenuItem";
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(420, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(429, 346);
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkViolet;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.btnNombre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(402, 320);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 43;
            // 
            // btnNombre
            // 
            this.btnNombre.HeaderText = "Citados";
            this.btnNombre.Name = "btnNombre";
            this.btnNombre.ReadOnly = true;
            this.btnNombre.Width = 48;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Violet;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1269, 664);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnHojaSuplente);
            this.Controls.Add(this.btnDatosFac);
            this.Controls.Add(this.btnNPaciente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.btnCambiar_Contra);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema GYO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHojaSuplente;
        private System.Windows.Forms.Button btnDatosFac;
        private System.Windows.Forms.Button btnNPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Button btnCambiar_Contra;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewButtonColumn btnNombre;
    }
}

